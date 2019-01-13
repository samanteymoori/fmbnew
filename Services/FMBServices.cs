using FMB.Model;
using FMBPublic.Model;
using FMBPublic.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Services
{
    public class FMBServices:IFMBServices
    {
        public FMBServices()
        {
        }
        public ConnectionSetting Cs { get; set; }



        public List<DashboardResult> GetDashboardResults(DataSetting setting)
        {
            List<DashboardResult> res = new List<DashboardResult>();
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(@"
                    IF OBJECT_ID('tempdb..#Dashboard') IS NOT NULL   DROP TABLE #Dashboard ;
                    IF OBJECT_ID('tempdb..#NPI') IS NOT NULL   DROP TABLE #NPI ;
                    IF OBJECT_ID('tempdb..#ClaimNumbers') IS NOT NULL  DROP TABLE #ClaimNumbers;
                    IF OBJECT_ID('tempdb..#HCFA') IS NOT NULL  DROP TABLE #HCFA;
                    IF OBJECT_ID('tempdb..#EDI') IS NOT NULL  DROP TABLE #EDI;
                    IF OBJECT_ID('tempdb..#DPT') IS NOT NULL  DROP TABLE #DPT;
                    IF OBJECT_ID('tempdb..#EBT') IS NOT NULL  DROP TABLE #EBT;
                    IF OBJECT_ID('tempdb..#temp') IS NOT NULL  DROP TABLE #temp
                    IF OBJECT_ID('tempdb..#t2') IS NOT NULL  DROP TABLE #t2
                    IF OBJECT_ID('tempdb..#claims') IS NOT NULL  DROP TABLE #claims
  
                    SELECT DISTINCT IDENTITY(int, 1,1) AS Id, NPI INTO #NPI from [dbo].[tblHCFALog];

                    DECLARE @MaxRow INT;
                    DECLARE @NextRow INT;
                    DECLARE @ClaimNum INT;
                    DECLARE @MaxID INT;
                    DECLARE @NPI INT;
                    DECLARE @NPICount INT;
                    DECLARE @ERA INT;
                    DECLARE @ProcessDate Smalldatetime;
                    SET @ProcessDate = cast((getdate() - 90 ) AS Smalldatetime);
                    set @NPICount = (SELECT max(id) from #NPI );

                    SET @NextRow = 1;
                    WHILE (@NextRow < (@NPICount + 1))
                    BEGIN

                    IF OBJECT_ID('tempdb..#Dashboard') IS NOT NULL   DROP TABLE #Dashboard ;
                    --IF OBJECT_ID('tempdb..#NPI') IS NOT NULL   DROP TABLE #NPI ;
                    IF OBJECT_ID('tempdb..#ClaimNumbers') IS NOT NULL  DROP TABLE #ClaimNumbers;
                    IF OBJECT_ID('tempdb..#HCFA') IS NOT NULL  DROP TABLE #HCFA;
                    IF OBJECT_ID('tempdb..#EDI') IS NOT NULL  DROP TABLE #EDI;
                    IF OBJECT_ID('tempdb..#DPT') IS NOT NULL  DROP TABLE #DPT;
                    IF OBJECT_ID('tempdb..#EBT') IS NOT NULL  DROP TABLE #EBT;
                    SET @NPI = (SELECT NPI from #NPI WHERE ID = @NextRow);

                    SELECT ID as PatientId,[ClaimNumber] ,[PatientFullName] , [ProviderFullName], [CarrierName], [DateFiled]  
                        ,isnull((cast([ChargeAmount1] as float)  * [DaysOrUnits1]) , 0 )
	                    + isnull((cast([ChargeAmount2] as float) * [DaysOrUnits2]) , 0 )
	                    + isnull((cast([ChargeAmount3] as float) * [DaysOrUnits3]) , 0 )
	                    + isnull((cast([ChargeAmount4] as float) * [DaysOrUnits4]) , 0 )
	                    + isnull((cast([ChargeAmount5] as float) * [DaysOrUnits5]) , 0 )
	                    + isnull((cast([ChargeAmount6] as float) * [DaysOrUnits6]) , 0 ) AS Billed
	                    , NULL As Insurance
	                    , NULL AS Adjustments
	                    , NULL AS PatientPay
	                    ,NULL As Balance    
                        ,[NPI]
	                    ,[TaxIDNumber]
	                    ,cast(NULL AS varchar(255)) AS Note
                    INTO #Dashboard
                    FROM [dbo].[tblHCFALog]
                    where cast([DateFiled] As Smalldatetime ) > @ProcessDate

                    -- now let's figure out the status of each claim by looping through #Dashboard
                    Alter table #Dashboard add  ClaimStatus varchar(255);
                    Alter table #Dashboard add  ClaimStatusDate varchar(255);
 
                    Update #Dashboard SET ClaimStatus = 'Initial Scrubbing';
                    DELETE FROM #Dashboard WHERE PATIENTID NOT IN (SELECT MAX(PATIENTID) FROM #Dashboard GROUP BY ClaimNumber);
                    select [claim_id],[accnt],[phys_id],[payer],[errors] 
                    INTO #HCFA
                    FROM [FMBStatusMaster].[dbo].[hcfa]
                    where phys_id = @NPI AND (accnt IN ( select DISTINCT ClaimNumber from #Dashboard));

                    DELETE FROM #HCFA WHERE [claim_id] NOT IN (SELECT MAX([claim_id]) FROM #HCFA GROUP BY accnt);

                    MERGE #Dashboard AS Target
                    USING #HCFA AS S
                    ON Target.ClaimNumber = S.accnt  AND Target.NPI = S.phys_id
                    WHEN MATCHED AND (Target.ClaimNumber = S.accnt)  AND (Target.NPI = S.phys_id)
                    THEN UPDATE SET  
                    Target.ClaimStatus = S.errors
                    ,Target.CarrierName  = S.payer
                    ;
                    IF OBJECT_ID('tempdb..#HCFA') IS NOT NULL  DROP TABLE #HCFA;
                    select [claim_id],[pat_accnt],[practice_id],[payer],[payer_response],[payer_process_dt] ,[timestamp]
                    INTO #EDI
                    FROM [FMBStatusMaster].[dbo].[edi]
                    where [practice_id] = @NPI AND ([pat_accnt] IN ( select DISTINCT ClaimNumber from #Dashboard));

                    DELETE FROM #EDI WHERE timestamp NOT IN (SELECT MAX(timestamp) FROM #EDI GROUP BY [pat_accnt]);

                    MERGE #Dashboard AS Target
                    USING #EDI AS S
                    ON Target.ClaimNumber = S.[pat_accnt]  AND Target.NPI = S.[practice_id]
                    WHEN MATCHED 
                    THEN UPDATE SET  
                    Target.ClaimStatus = S.[payer_response]
                    ,Target.CarrierName  = S.payer
                    ,Target.ClaimStatusDate = S.[payer_process_dt]
                    ;

                    IF OBJECT_ID('tempdb..#EDI') IS NOT NULL  DROP TABLE #EDI;
                    ------------
                    select [Payer_Claim_Number],[Patient_Account_Number],[Billing_Provider_ID],[Payer_Name],[Message_Text],[Date_Received] ,[timestamp]
                    INTO #DPT
                    FROM [FMBStatusMaster].[dbo].[dpt]
                    where [Billing_Provider_ID] = @NPI AND ([Patient_Account_Number] IN ( select DISTINCT ClaimNumber from #Dashboard));

                    DELETE FROM #DPT WHERE timestamp NOT IN (SELECT MAX(timestamp) FROM #DPT GROUP BY [Patient_Account_Number]);

                    MERGE #Dashboard AS Target
                    USING #DPT AS S
                    ON Target.ClaimNumber = S.[Patient_Account_Number]  AND Target.NPI = S.[Billing_Provider_ID]
                    WHEN MATCHED 
                    THEN UPDATE SET  
                    Target.ClaimStatus = S.[Message_Text]
                    ,Target.CarrierName  = S.[Payer_Name]
                    ,Target.ClaimStatusDate = S.[Date_Received]
                    ;
                    IF OBJECT_ID('tempdb..#DPT') IS NOT NULL  DROP TABLE #DPT;
                    ---------------------------
                    select [Patient_Control_Number],[Provider_Billing_ID],[Message_Initiator],[Message],[Date_Received] ,ID
                    INTO #EBT
                    FROM [FMBStatusMaster].[dbo].[EBT]
                    where [Provider_Billing_ID] = @NPI AND ([Patient_Control_Number] IN ( select DISTINCT ClaimNumber from #Dashboard));

                    DELETE FROM #EBT WHERE id NOT IN (SELECT MAX(id) FROM #EBT GROUP BY [Patient_Control_Number]);

                    MERGE #Dashboard AS Target
                    USING #EBT AS S
                    ON Target.ClaimNumber = S.[Patient_Control_Number]  AND Target.NPI = S.[Provider_Billing_ID]
                    WHEN MATCHED 
                    THEN UPDATE SET  
                    Target.ClaimStatus = S.[Message]
                    ,Target.CarrierName  = S.[Message_Initiator]
                    ,Target.ClaimStatusDate = S.[Date_Received]
                    ;
                    IF OBJECT_ID('tempdb..#EBT') IS NOT NULL  DROP TABLE #EBT;

                    SET @NextRow = @NextRow + 1;
                    END


                    SELECT IDENTITY(int, 1,1) AS Id
                        
                        ,[ClaimNumber]
                        ,[PatientFullName]      
                        ,[ChargeAmount1],[DaysOrUnits1]
                        ,[ChargeAmount2],[DaysOrUnits2]
                    ,[ChargeAmount3],[DaysOrUnits3]
                    ,[ChargeAmount4],[DaysOrUnits4]
                    ,[ChargeAmount5],[DaysOrUnits5]
                    ,[ChargeAmount6],[DaysOrUnits6]
	                    into #temp 
                    FROM [dbo].[tblHCFALog]
                    where ClaimNumber IN (SELECT ClaimNumber from #DashBoard);

                    Set @MaxRow = (select max(ID) from #temp);
                    Set @NextRow = 1;

                    while (@NextRow < @MaxRow + 1)
                    Begin
                    set @ClaimNum = (select claimnumber   from #temp where ID = @NextRow);
                    set @MaxID = (select max(id) from #temp where claimnumber = @ClaimNum);
                    delete from #temp where claimnumber = @ClaimNum AND ID <> @MaxID
                    set @NextRow = @NextRow + 1
                    END
                    alter table #temp add Charges AS (isnull([ChargeAmount1],0) 
                    + isnull([ChargeAmount2],0)
                    + isnull([ChargeAmount4],0)
                    + isnull([ChargeAmount5],0)
                    + isnull([ChargeAmount6],0)
                    ); 
                    alter table #temp add 
                    ManagedCare float
                    , PatientCheck float
                    , PatientCreditCard float
                    , PatientCash float
                    , PrimaryIns float
                    , Balance float
                    ;


                    DECLARE @Amount float;
                    DECLARE @ManagedCare float;
                    DECLARE @PatientCheck float;
                    DECLARE @PatientCreditCard float;
                    DECLARE @PatientCash float;
                    DECLARE @PrimaryIns float;
                    DECLARE @Balance float;

                    Set @MaxRow = (select max(ID) from #temp);
                    Set @NextRow = 1;

                    while (@NextRow < @MaxRow + 1 )
                    Begin
                    set @ClaimNum = (select Claimnumber from #temp where ID = @NextRow);
                    set @Amount = (select isnull(sum(amount),0) from [dbo].[tblTransactions] where claimnumber =  @ClaimNum AND TransactionType = 1)
                    set @ManagedCare = (select isnull(sum(amount),0) from [dbo].[tblTransactions] where claimnumber =  @ClaimNum AND TransactionType = 3)
                    set @PatientCheck = (select isnull(sum(amount),0) from [dbo].[tblTransactions] where claimnumber =  @ClaimNum AND TransactionType = 5)
                    set @PatientCreditCard = (select isnull(sum(amount),0) from [dbo].[tblTransactions] where claimnumber =  @ClaimNum AND TransactionType = 6)
                    set @PatientCash = (select isnull(sum(amount),0) from [dbo].[tblTransactions] where claimnumber =  @ClaimNum AND TransactionType = 7)
                    set @PrimaryIns = (select isnull(sum(amount),0) from [dbo].[tblTransactions] where claimnumber =  @ClaimNum AND TransactionType = 9)

                    set @Balance = (
                    @Amount 
                    - @ManagedCare 
                    - @PatientCheck
                    - @PatientCreditCard
                    - @PatientCash
                    - @PrimaryIns);
                    update #temp set 
                    ManagedCare = @ManagedCare
                    , PatientCheck = @PatientCheck
                    , PatientCreditCard = @PatientCreditCard
                    , PatientCash = @PatientCash
                    , PrimaryIns = @PrimaryIns
                    , Balance = @Balance
                    where ID = @NextRow
                    ;


                    UPDATE #DashBoard
                    SET Billed = (SELECT Charges from #temp where ClaimNumber = @ClaimNum) 
                    ,Insurance = (SELECT PrimaryIns from #temp where ClaimNumber = @ClaimNum) 
                    ,Adjustments = (SELECT ManagedCare from #temp where ClaimNumber = @ClaimNum)
                    ,PatientPay = (SELECT (PatientCheck + PatientCreditCard + PatientCash) from #temp where ClaimNumber = @ClaimNum) 
                    ,Balance = (SELECT Balance from #temp where ClaimNumber = @ClaimNum)
                    WHERE ClaimNumber = @ClaimNum;

                    update #DashBoard  set Note = case when (SELECT count(account) FROM [FMBStatusMaster].dbo.checkdata WHERE npi in (select NPI from #NPI)  AND account = @ClaimNum) = 1 then 'ERA' ELSE '' END
                    WHERE ClaimNumber = @ClaimNum;

                    set @NextRow = @NextRow + 1;
                    end
                    

                    SELECT * INTO #filter FROM #Dashboard 
			        WHERE (ClaimNumber LIKE '%'+@Criteria+'%'
			        OR PatientFullName LIKE  '%'+@Criteria+'%'
			        OR ProviderFullName LIKE  '%'+@Criteria+'%'
			        OR CarrierName LIKE  '%'+@Criteria+'%' 
			        OR DateFiled LIKE  '%'+@Criteria+'%' 
			        OR ClaimStatus LIKE  '%'+@Criteria+'%'
			        OR Billed LIKE  '%'+@Criteria+'%' 
			        OR Insurance LIKE  '%'+@Criteria+'%'
			        OR Adjustments LIKE  '%'+@Criteria+'%'
			        OR PatientPay LIKE  '%'+@Criteria+'%' 
			        OR Balance LIKE  '%'+@Criteria+'%'
			        OR @Criteria  IS NULL) AND (claimnumber in (
					select claimnumber from tblClaim where accountnumber=(select accountNumber from tblClaim where claimnumber=@PatientId)
					)  OR @PatientId IS NULL)

                    declare  @CNT int=(SELECT COUNT(*) FROM #filter)
                  	SELECT TOP ( @PAGE_SIZE) claimnumber,Patientfullname,providerfullname, Carriername,Datefiled, ClaimStatus,Billed,Insurance,Adjustments,PatientPay,Balance         , Note,Action,@CNT CNT,RN,PatientId FROM (
                    select row_number() OVER (ORDER BY CLAIMNUMBER DESC) RN,claimnumber,PatientId,Patientfullname,providerfullname, Carriername,Datefiled, ClaimStatus,Billed,Insurance,Adjustments,PatientPay,Balance
                    , Note,NULL AS Action
                    from #filter
					) AS SUB 
					WHERE  RN > (@PAGE_SIZE * @PAGE_INDEX)
                    ", conn))
                {
                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@PAGE_SIZE", setting.PageSize);
                    comm.Parameters.AddWithValue("@PAGE_INDEX", setting.PageIndex);
                    comm.Parameters.AddWithValue("@Criteria", setting.SearchCriteria);
                    if(setting.PatientId.HasValue)
                        comm.Parameters.AddWithValue("@PatientId", setting.PatientId.Value);
                    else
                        comm.Parameters.AddWithValue("@PatientId", DBNull.Value);
                    var reader = comm.ExecuteReader();
                    
                    object[] o = new object[reader.FieldCount];
                    while (reader.Read())
                    {

                    
                        reader.GetValues(o);
                        res.Add(new DashboardResult()
                        {
                           claimnumber = int.Parse(o[0].ToString()),
                            Patientfullname= (o[1].ToString()),
                            providerfullname= o[2].ToString(),
                            Carriername= o[3].ToString(),
                            Datefiled= DateTime.Parse(o[4].ToString()),
                            ClaimStatus= (o[5].ToString()),
                            Billed= float.Parse(o[6].ToString()),
                            Insurance= int.Parse(o[7].ToString()),
                            Adjustments= int.Parse(o[8].ToString()),
                            PatientPay= int.Parse(o[9].ToString()),
                            Balance= int.Parse(o[10].ToString()),
                            Note= (o[11].ToString()),
                            Action=0,
                            VirtualItemCount = int.Parse(o[13].ToString()),
                            rn= int.Parse(o[14].ToString()),
                            PatientId= int.Parse(o[15].ToString())
                        });
                    }
                    conn.Close();
                }
            }
            return res;
        }

        public int? GetAccountNumberByClaimNumber(int ClaimNumber)
        {
            int? result = null;
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT AccountNumber FROM tblClaim 
                    WHERE ClaimNumber=@ClaimNumber", conn))
                {
                    
                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@ClaimNumber", ClaimNumber);
                    var res = comm.ExecuteScalar();
                    if (res != null)
                        result = int.Parse(res.ToString());
                    conn.Close();
                }

            }
            return result;
        }

        public PatientViewModel GetPatientDetailByAccountNo(int AccountNumber)
        {
            PatientViewModel pvm = new PatientViewModel();
            Patient result = new Patient();
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM tblPatient 
                    WHERE AccountNumber=@AccountNumber", conn))
                {

                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(Patient);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {
                            
                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    
                    conn.Close();
                    pvm.Patient = result;
                    pvm.PatientHist = GetPatientHistByPatientId(GetParam(pvm.Patient.PatientID));
                    pvm.Provider = GetProviderById( pvm.Patient.ProviderCode);
                    pvm.NPI = GetProviderNPI();
                    pvm.ServiceTypes= GetServiceTypes();
                    pvm.PlaceOfServices= GetPlaceOfServices();
                    pvm.Providers = GetProviders();
                    pvm.Payers= GetPayers();
                    pvm.Phone1 = GetPhoneById(GetParam(pvm.PatientHist.Phone1ID));
                    pvm.Phone2 = GetPhoneById(GetParam(pvm.PatientHist.Phone2ID));
                    pvm.Address= GetAddressById(GetParam(pvm.PatientHist.AddressID));
                    pvm.BillingAddress= GetAddressById(GetParam(pvm.PatientHist.BillingAddressID));
                    pvm.PrimaryInsured = GetInsuredById((GetParam(pvm.PatientHist.PrimaryInsuredID)));
                    pvm.InsuredPhone1= GetPhoneById((GetParam(pvm.PrimaryInsured.Phone1ID)));
                    pvm.InsuredPhone2 = GetPhoneById((GetParam(pvm.PrimaryInsured.Phone2ID)));
                    pvm.InsuredAddress= GetAddressById((GetParam(pvm.PrimaryInsured.AddressID)));

                    pvm.SecondaryInsured= GetInsuredById((GetParam(pvm.PatientHist.SecondaryInsuredID)));
                    pvm.OtherInsured= GetInsuredById((GetParam(pvm.PatientHist.OtherInsuredID)));

                    pvm.Guarantor= GetGuarantorById((GetParam(pvm.PatientHist.GuarantorID)));
                    if (pvm.Guarantor != null)
                    {
                        pvm.GuarantorAddress = GetAddressById((GetParam(pvm.Guarantor.AddressID)));
                        pvm.GuarantorPhone1 = GetPhoneById((GetParam(pvm.Guarantor.Phone1ID)));
                        pvm.GuarantorPhone2= GetPhoneById((GetParam(pvm.Guarantor.Phone2ID)));
                        pvm.GuarantorAddress.State = "AZ";
                    }
                }

            }
            return pvm;
        }

        private int GetParam(string patientID)
        {
            if (string.IsNullOrEmpty(patientID))
                return -1;
            else
                return int.Parse(patientID);
        }

        public PatientHist GetPatientHistByPatientId(int PatientId)
        {
            PatientHist result = new PatientHist();
            if (PatientId == -1)
                return result;
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM tblPatientHist
                    WHERE PatientId=@PatientId", conn))
                {

                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@PatientId", PatientId);
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(PatientHist);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    conn.Close();
                }

            }
            return result;
        }

        public Insured GetInsuredById(int Id)
        {
            Insured result = new Insured();
            if (Id == -1)
                return result;
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM tblInsured
                    WHERE InsuredId=@InsuredId", conn))
                {

                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@InsuredId", Id);
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(Insured);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    conn.Close();
                }

            }
            return result;
        }
        public Guarantor GetGuarantorById(int Id)
        {
            Guarantor result = new Guarantor();
            if (Id == -1)
                return result;
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM tblGuarantor
                    WHERE GuarantorId=@GuarantorId", conn))
                {

                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@GuarantorId", Id);
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(Guarantor);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    conn.Close();
                }

            }
            return result;
        }

        public Address GetAddressById(int Id)
        {
            Address result = new Address();
            if (Id == -1)
                return result;
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM tblAddress
                    WHERE AddressId=@AddressId", conn))
                {

                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@AddressId", Id);
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(Address);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    conn.Close();
                }

            }
            return result;
        }

        public Phone GetPhoneById(int Id)
        {
            Phone result = new Phone();
            if (Id == -1)
                return result;
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM tblPhone
                    WHERE PhoneId=@PhoneId", conn))
                {

                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@PhoneId", Id);
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(Phone);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    conn.Close();
                }

            }
            return result;
        }

        public Provider GetProviderById(string code)
        {
            Provider result = new Provider();
           
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM tblProvider
                    WHERE ProviderCode=@ProviderCode", conn))
                {

                    comm.CommandTimeout = 0;
                    comm.Parameters.AddWithValue("@ProviderCode", code);
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(Provider);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    conn.Close();
                }

            }
            return result;
        }

        public CoverageVerificationResponse CoverageVerification(CoverageVerificationRequest request)
        {
            throw new NotImplementedException();
        }

        public List<Provider> GetProviders()
        {
            List<Provider> lst = new List<Provider>();
            
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"select * from tblprovider", conn))
                {
                   
                    comm.CommandTimeout = 0;
                
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        Provider result = new Provider();
                        var t = typeof(Provider);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                        lst.Add(result);
                    }
                 
                    conn.Close();
                }

            }
            return lst;
        }

        public List<ServiceType> GetServiceTypes()
        {
            List<ServiceType> lst = new List<ServiceType>();

            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM  FMBPublic.[dbo].[FMBServiceType] WHERE [TypeCode] IS NOT NULL", conn))
                {

                    comm.CommandTimeout = 0;

                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        ServiceType result = new ServiceType();
                        var t = typeof(ServiceType);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                        lst.Add(result);
                    }

                    conn.Close();
                }

            }
            return lst;
        }

        public List<PlaceOfService> GetPlaceOfServices()
        {
            List<PlaceOfService> lst = new List<PlaceOfService>();

            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM  FMBPublic.[dbo].FMBPlaceofService WHERE PlaceOfServiceCode IS NOT NULL", conn))
                {

                    comm.CommandTimeout = 0;

                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        PlaceOfService result = new PlaceOfService();
                        var t = typeof(PlaceOfService);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                        lst.Add(result);
                    }

                    conn.Close();
                }

            }
            return lst;
        }

        public NPIModel GetProviderNPI()
        {
            NPIModel result = new NPIModel();
            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT       DISTINCT  zy_pr_Provider.NPI, tblProvider.LastName, tblProvider.FirstName, tblProvider.MiddleName,  tblProvider.Status 
                        FROM            tblProvider INNER JOIN
                        zy_pr_Provider ON tblProvider.ProviderCode = zy_pr_Provider.ProviderCode", conn))
                {

                    comm.CommandTimeout = 0;
                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        var t = typeof(NPIModel);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                    }
                    conn.Close();
                }

            }
            return result;
        }

        public List<Payer> GetPayers()
        {
            List<Payer> lst = new List<Payer>();

            using (SqlConnection conn = new SqlConnection(Cs.GetConnection()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(
                    @"SELECT * FROM fmbpublic.dbo.fmb270payer", conn))
                {

                    comm.CommandTimeout = 0;

                    var res = comm.ExecuteReader();
                    while (res.Read())
                    {
                        Payer result = new Payer();
                        var t = typeof(Payer);
                        var pr = t.GetProperties();
                        int i = 0;
                        foreach (var item in pr)
                        {

                            item.SetValue(result, res[i].ToString());
                            i++;
                        }
                        lst.Add(result);
                    }

                    conn.Close();
                }

            }
            return lst;
        }
    }
}
