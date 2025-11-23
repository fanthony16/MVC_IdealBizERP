using IdealBizUI.Data;
using IdealBizUI.InterfaceServices;
using IdealBizUI.Models;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IUserManager _uManager;
        private readonly IdealBizContext _dbcontext;

        public CompaniesController(IUserManager _Manager, IdealBizContext _Idbcontext)
        {
            _uManager = _Manager;
            _dbcontext = _Idbcontext;
        }
        public IActionResult Index()
        {
            View_Company vwcompany = new View_Company();

            try
            {
                List<TblCompany> db_companies = _dbcontext.TblCompanies.ToList();
                List<Company> _companies = new List<Company>();

                foreach (var org in db_companies)
                {
                    var _ = new Company
                    {
                        CompanyID = org.IntCompany,
                        CompanyName = org.TxtCompanyName,
                        CompanyAddress = org.TxtCompanyAddress,
                        ContactPhone = org.TxtContactPhone,
                        OfficePhone = org.TxtOfficePhone,
                        EmailAddress = org.TxtEmailAddress,
                        ApplyVat = org.BlnApplyVat ?? false,
                        blnConnect2GL = org.BlnConnect2Gl ?? false,
                        VatRate = org.NumVatRate

                    };

                    _companies.Add(_);
                };

                vwcompany.Companies = _companies;
                return View(vwcompany);
            }
            catch (Exception e)
            {
                return View(vwcompany);
            }
            

        }
        [HttpGet]
        public IActionResult Create()
        {

            var _ledgeraccounts = _dbcontext.TblAccountCharts.ToList().ConvertAll(c => new SelectListItem
            {
                Value = c.TxtAccountNumber.ToString(),
                Text = c.TxtAccountName

            });

            var _accountledgers = new Company
            {
                AccountsChart = _ledgeraccounts
            };

            return View(_accountledgers);
        }

        public IActionResult Edit(int id)
        {

            var _ledgeraccounts = _dbcontext.TblAccountCharts.ToList().ConvertAll(c => new SelectListItem
            {
                Value = c.TxtAccountNumber.ToString(),
                Text = c.TxtAccountName

            });

            var _companyDB = _dbcontext.TblCompanies.FirstOrDefault(coy => coy.IntCompany == id);

            if (_companyDB != null)
            {

                //var _companyDB = _dbcontext.TblCompanies.Find(id);

                var _company = new Company
                {
                    CompanyID = _companyDB.IntCompany,
                    CompanyAddress = _companyDB.TxtCompanyAddress,
                    CompanyName = _companyDB.TxtCompanyName,
                    ContactPhone = _companyDB.TxtContactPhone,
                    EmailAddress = _companyDB.TxtEmailAddress,
                    ApplyVat = _companyDB.BlnApplyVat ?? false,
                    blnConnect2GL = _companyDB.BlnConnect2Gl ?? false,
                    GeneralIncomeLedger = _companyDB.TxtGeneralIncomeLedger,
                    InventoryExpenseLedger = _companyDB.TxtInventoryExpenseLedger,
                    InventoryIncomeLedger = _companyDB.TxtInventoryIncomeLedger,
                    InventoryLedger = _companyDB.TxtInventoryLedger,
                    OfficePhone = _companyDB.TxtOfficePhone,
                    PayableLedger = _companyDB.TxtPayableLedger,
                    RecievableLedger = _companyDB.TxtRecievableLedger,
                    VatLedger = _companyDB.TxtVatLedger,
                    VatRate = _companyDB.NumVatRate,
                    AccountsChart = _ledgeraccounts
                };
                return View(_company);
            }


            return View(new Company());



        }


        public IActionResult GetCompany(int id)
        {

            var coy = _dbcontext.TblCompanies.Find(id);
            return Json(coy);
        }
        [HttpPost]
        public IActionResult Update(View_Company compViewModel)
        {

            var _coy = _dbcontext.TblCompanies.Find(compViewModel.MyCompany.CompanyID);
            _coy.TxtCompanyName = compViewModel.MyCompany.CompanyName;
            _dbcontext.TblCompanies.Update(_coy);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Edit(Company _company)
        {
            if (ModelState.IsValid)
            {

                var _dbCompany = _dbcontext.TblCompanies.FirstOrDefault(coy => coy.IntCompany == _company.CompanyID);
                if (_dbCompany != null)
                {
                    _dbCompany.TxtCompanyName = _company.CompanyName;
                    _dbCompany.TxtCompanyAddress = _company.CompanyAddress;
                    _dbCompany.TxtContactPhone = _company.ContactPhone;
                    _dbCompany.TxtEmailAddress = _company.EmailAddress;
                    _dbCompany.TxtOfficePhone = _company.OfficePhone;
                    _dbCompany.TxtGeneralIncomeLedger = _company.GeneralIncomeLedger;
                    _dbCompany.TxtInventoryExpenseLedger = _company.InventoryExpenseLedger;
                    _dbCompany.TxtInventoryIncomeLedger = _company.InventoryIncomeLedger;
                    _dbCompany.TxtInventoryLedger = _company.InventoryLedger;
                    _dbCompany.TxtPayableLedger = _company.PayableLedger;
                    _dbCompany.TxtRecievableLedger = _company.RecievableLedger;
                    _dbCompany.TxtVatLedger = _company.VatLedger;
                    _dbCompany.BlnApplyVat = _company.ApplyVat;
                    _dbCompany.BlnConnect2Gl = _company.blnConnect2GL;
                    _dbCompany.NumVatRate = _company.VatRate;
                    _dbcontext.TblCompanies.Update(_dbCompany);
                    _dbcontext.SaveChanges();

                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(View_Company _company)
        {
            //if (ModelState.IsValid)
            //{
            //    var _nwCompany = new TblCompany
            //    {
            //        TxtCompanyName = _company.CompanyName,
            //        TxtCompanyAddress = _company.CompanyAddress,
            //        TxtContactPhone = _company.ContactPhone,
            //        TxtEmailAddress = _company.EmailAddress,
            //        TxtOfficePhone = _company.OfficePhone,
            //        TxtGeneralIncomeLedger = _company.GeneralIncomeLedger,
            //        TxtInventoryExpenseLedger = _company.InventoryExpenseLedger,
            //        TxtInventoryIncomeLedger = _company.InventoryIncomeLedger,
            //        TxtInventoryLedger = _company.InventoryLedger,
            //        TxtPayableLedger = _company.PayableLedger,
            //        TxtRecievableLedger = _company.RecievableLedger,
            //        TxtVatLedger = _company.VatLedger,
            //        BlnApplyVat = _company.ApplyVat,
            //        BlnConnect2Gl = _company.blnConnect2GL,
            //        NumVatRate = _company.VatRate
            //    };


            var _nwCompany = new TblCompany
            {
                TxtCompanyName = _company.MyCompany.CompanyName
            };


                _dbcontext.TblCompanies.Add(_nwCompany);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");

            }
            //else
            //{
            //    var _ledgeraccounts = _dbcontext.TblAccountCharts.ToList().ConvertAll(c => new SelectListItem
            //    {
            //        Value = c.TxtAccountNumber.ToString(),
            //        Text = c.TxtAccountName

            //    });

            //    var _accountledgers = new Company
            //    {
            //        AccountsChart = _ledgeraccounts
            //    };
            //    return View(_accountledgers);
            //}
           

            
        //}

        public JsonResult Delete(int id)
        {
            bool result = false;
            try {

                //var _company = _dbcontext.TblCompanies.Find(id);

                var _company = _dbcontext.TblCompanies.FirstOrDefault(e => e.IntCompany == id);

                if (_company != null)
                {
                    result = true;
                    _dbcontext.TblCompanies.Remove(_company);
                    _dbcontext.SaveChanges();
                }

                return Json(result);
            }
            catch (Exception e)
            {
                return Json(result);
            }
            

        }
    }
}
