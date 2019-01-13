using FMB.Model;
using FMBPublic.Model;
using System.Collections.Generic;

namespace FMB.Services
{
    public interface IFMBServices
    {
        ConnectionSetting Cs { get; set; }
        List<DashboardResult> GetDashboardResults(DataSetting setting);
        int? GetAccountNumberByClaimNumber(int ClaimNumber);

        PatientViewModel GetPatientDetailByAccountNo(int AccountNumber);

        PatientHist GetPatientHistByPatientId(int PatientId);

        Insured GetInsuredById(int Id);

        Address GetAddressById(int Id);

        Phone GetPhoneById(int Id);

        Guarantor GetGuarantorById(int Id);
        //DONE implement getting provider by id
        Provider GetProviderById(string code);
        //DONE implement getting providers
        List<Provider> GetProviders();
        //DONE implement getting service types
        List<ServiceType> GetServiceTypes();
        //DONE implement getting Place Of Services
        List<PlaceOfService> GetPlaceOfServices();
        //DONE implement getting Provider NPI
        NPIModel GetProviderNPI();
        //DONE implement getting payers
        List<Payer> GetPayers();

        CoverageVerificationResponse CoverageVerification(CoverageVerificationRequest request);
    }
}