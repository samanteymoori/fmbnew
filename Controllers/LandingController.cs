﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FMBPublic.Model;
using FMBPublic.Services;
using Microsoft.AspNetCore.Authorization;
using FMB.Model;
using FMB.Controllers;
using System.Security.Claims;
using FMB.Services;
using Microsoft.AspNetCore.Authentication;
using System.Text;

namespace FMBPublic.Controllers
{
    
    public class LandingController : Controller
    {
        private FMB.Controllers.IAuthenticationService _service;
        private IFMBServices _fmbService;
        public LandingController(
            FMB.Controllers.IAuthenticationService service,
            IFMBServices fmbService)
        {
            _service = service;
            _fmbService = fmbService;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cms1500()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = SchemesNamesConst.UserAuthenticationDefaultScheme)]
        [HttpGet]
        public IActionResult Dashboard()
        {
            //byte[] database = null;
            //if (HttpContext.Session.TryGetValue("database", out database))
            //{
            //    _fmbService.Cs = Connection.GetCs();
            //    _fmbService.Cs.DataBase = UTF8Encoding.UTF8.GetString(database);
            //    int itemCount = 0;
            //    var result = _fmbService.GetDashboardResults(new DataSetting() { PageIndex=0,PageSize=10,SearchCriteria=""},out itemCount);
            //    return View(result);
            //}
            //throw new InvalidOperationException();
            return View();
        }
        [Authorize(AuthenticationSchemes = SchemesNamesConst.UserAuthenticationDefaultScheme)]
        [HttpGet]
        public IActionResult Patient(int Id)
        {

            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = SchemesNamesConst.UserAuthenticationDefaultScheme)]
        [HttpGet]
        public IActionResult PatientDetail(int Id)
        {
            byte[] database = null;
            PatientViewModel p = null;
            if (HttpContext.Session.TryGetValue("database", out database))
            {
                _fmbService.Cs = Connection.GetCs();
                _fmbService.Cs.DataBase = UTF8Encoding.UTF8.GetString(database);
                var result = _fmbService.GetAccountNumberByClaimNumber(Id);
                if(result.HasValue)
                {
                    p = _fmbService.GetPatientDetailByAccountNo(result.Value);
                }

                return Json(p);
            }
            return View();
        }
        [Authorize(AuthenticationSchemes = SchemesNamesConst.UserAuthenticationDefaultScheme)]
        [HttpPost]
        public IActionResult Dashboard([FromBody]DataSetting setting)
        {
            byte[] database = null;
            if (HttpContext.Session.TryGetValue("database", out database))
            {
                _fmbService.Cs = Connection.GetCs();
                _fmbService.Cs.DataBase = UTF8Encoding.UTF8.GetString(database);
                var result = _fmbService.GetDashboardResults(setting);
                return Json(result);
            }
            throw new InvalidOperationException();
        }
        public IActionResult E401()
        {
            return RedirectToAction("Login");
        }
        public IActionResult E404()
        {
            return RedirectToAction("Login");
        }
        public IActionResult E403()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login(int? Id = null)
        {
            if (Id.HasValue && Id.Value == 1)
            {
                ViewBag.Message = "Invalid username or password.";
            }
            else
            {
                ViewBag.Message = "";
            }
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Authenticate(String UserName, String Password)
        {
            var usr = _service.Authenticate(Connection.GetWebInfoCs().GetConnection(), UserName, Password);
            if (usr == null)
            {
                return RedirectToAction("Login", new { id = 1 });
            }
            HttpContext.Session.Set("usr", 
                UTF8Encoding.UTF8.GetBytes( 
                    usr.WebUserID.ToString()));
            return RedirectToAction("DatabaseChoose");
        }
        [Authorize(AuthenticationSchemes = SchemesNamesConst.UserAuthenticationDefaultScheme)]
        public IActionResult DatabaseChoose()
        {
            byte[] user = null;
            if (HttpContext.Session.TryGetValue("usr", out user))
            {
                var ad = _service.GetAccessibleDatabases(
                    Connection
                    .GetWebInfoCs()
                    .GetConnection(),
                    UTF8Encoding.UTF8.GetString(user));
                if (ad.Count == 1)
                {
                    return RedirectToAction("SelectDatabase", new { database = ad.First().ClientDatabase });
                }
                return View(ad);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [Authorize(AuthenticationSchemes = SchemesNamesConst.UserAuthenticationDefaultScheme)]
        public IActionResult SelectDatabase(string database)
        {
            byte[] user = null;
            if (HttpContext.Session.TryGetValue("usr", out user))
            {
                var ad = _service.GetAccessibleDatabases(
                    Connection
                    .GetWebInfoCs()
                    .GetConnection(),
                    UTF8Encoding.UTF8.GetString(user));
                if (ad
                    .Where(p => p.ClientDatabase == database)
                    .FirstOrDefault() != null)
                {
                    var cs = Connection.GetCs(database);
                    HttpContext.Session.Set("database",UTF8Encoding.UTF8.GetBytes(database.ToString()));
                    return RedirectToAction("Dashboard");
                }
                throw new InvalidOperationException();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

    }
}
