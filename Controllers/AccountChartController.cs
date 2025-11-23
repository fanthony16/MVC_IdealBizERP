using IdealBizUI.Data;
using IdealBizUI.QueryManager;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IdealBizUI.Controllers
{
    public class AccountChartController : BaseController<View_AccountChart>
    {

        private readonly IdealBizContext _dbcontext;
        private readonly CodeUnits _codeunit;


        public AccountChartController(IdealBizContext _Idbcontext, CodeUnits codeUnit)
        {
            _dbcontext = _Idbcontext;
            _codeunit = codeUnit;
        }
        public IActionResult Index(int page = 1, string name="")
        {
            name = string.IsNullOrEmpty(name) ? "" : name.ToLower();
            
            var dbAccountCharts = _dbcontext.TblAccountCharts.Where(c => c.TxtAccountName.ToLower().Contains(name) ).ToList();

            List<View_AccountChart> vm_AccountChart = new List<View_AccountChart>();

            try {

                foreach (var acChart in dbAccountCharts)
                {

                    View_AccountChart _accountchart = new()
                    {

                        intAccountGroup = _dbcontext.TblAccountGroups.Where(c => c.IntAccountGroup == acChart.IntAccountGroup).Select(c => c.TxtAccountGroupName).FirstOrDefault(),
                        IntAccountType = (Convert.ToString(acChart.IntAccountType ?? 0) == "1")? "Posting" : (Convert.ToString(acChart.IntAccountType ?? 0) == "2") ? "Heading" : (Convert.ToString(acChart.IntAccountType ?? 0) == "3") ? "Total" : (Convert.ToString(acChart.IntAccountType ?? 0) == "4") ? "Begin_Total" : "End_Total",
                        IntIncomeOrBalance = (Convert.ToString(acChart.IntIncomeOrBalance ?? 0) == "0") ? "Income" :"Balance",
                        intPostingType = (Convert.ToString(acChart.IntPostingType ?? 0) == "0") ? "" : (Convert.ToString(acChart.IntPostingType ?? 0) == "1") ? "Debit" : (Convert.ToString(acChart.IntPostingType ?? 0) == "2") ? "Credit" : "Both",
                        intRecID = acChart.IntRecId,
                        isBlocked = acChart.IsBlocked ?? false,
                        isPosting = acChart.IsPosting ?? false,
                        txtAccountName = acChart.TxtAccountName,
                        txtAccountNumber = acChart.TxtAccountNumber
                        
                    };

                    vm_AccountChart.Add(_accountchart);

                };

                var paginatedResult = PaginatedResult(vm_AccountChart, page, 20);

                return View(paginatedResult);
            }
            catch (Exception e)
            {
                
                return View(vm_AccountChart);
            }

            

           

            
        }


        public IActionResult Edit(string id)
        {
            try {

                var accountGroups = _dbcontext.TblAccountGroups.ToList().ConvertAll(x => new SelectListItem {
                Text = x.TxtAccountGroupName,
                Value = x.IntAccountGroup.ToString()
                });
                    
                


                var dbAccountChart = _dbcontext.TblAccountCharts.Where(x => x.TxtAccountNumber == id).Single();
                var vmAccountChart = new View_AccountChart
                {
                    intAccountGroup = dbAccountChart.IntAccountGroup.ToString(),
                    IntAccountType = dbAccountChart.IntAccountType.ToString(),
                    intPostingType = dbAccountChart.IntPostingType.ToString(),
                    IntIncomeOrBalance = dbAccountChart.IntIncomeOrBalance.ToString(),
                    isBlocked = dbAccountChart.IsBlocked ?? false,
                    isPosting = dbAccountChart.IsPosting ?? false,
                    txtAccountName = dbAccountChart.TxtAccountName,
                    txtAccountNumber = dbAccountChart.TxtAccountNumber,
                    intRecID = dbAccountChart.IntRecId
                };
                vmAccountChart.AccountGroups = accountGroups;
                return View(vmAccountChart);

            }
            catch (Exception e)
            {
                View_AccountChart vwMode = new();
                return View(vwMode);
            }
            
        }

        [HttpPost]
        public IActionResult Edit(View_AccountChart _accChart)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var dbAccledger = _dbcontext.TblAccountCharts.Where(x => x.TxtAccountNumber == _accChart.txtAccountNumber).FirstOrDefault();

                    if(dbAccledger != null)
                    {

                        dbAccledger.TxtAccountName = _accChart.txtAccountName;
                        dbAccledger.IntAccountGroup = Convert.ToInt32(_accChart.intAccountGroup);
                        dbAccledger.IntAccountType = Convert.ToInt32(_accChart.IntAccountType);
                        dbAccledger.IntIncomeOrBalance = Convert.ToInt32(_accChart.IntIncomeOrBalance);
                        dbAccledger.IntPostingType = Convert.ToInt32(_accChart.intPostingType);
                        dbAccledger.IsBlocked = (_accChart.isBlocked);
                        dbAccledger.IsPosting = (_accChart.isPosting);

                    }
                    
                    _dbcontext.TblAccountCharts.Update(dbAccledger).Property(x => x.IntRecId).IsModified = false;

                    _dbcontext.SaveChanges();
                }

                
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");

            }

        }

        public IActionResult Delete(string id)
        {

            try {

                var dbAccLedger = _dbcontext.TblAccountCharts.Where(x => x.TxtAccountNumber == id).SingleOrDefault();
                View_AccountChart vwAccountChart = new()
                {

                    intAccountGroup = _dbcontext.TblAccountGroups.Where(c => c.IntAccountGroup == dbAccLedger.IntAccountGroup).Select(c => c.TxtAccountGroupName).FirstOrDefault(),
                    IntAccountType = (Convert.ToString(dbAccLedger.IntAccountType ?? 0) == "1") ? "Posting" : (Convert.ToString(dbAccLedger.IntAccountType ?? 0) == "2") ? "Heading" : (Convert.ToString(dbAccLedger.IntAccountType ?? 0) == "3") ? "Total" : (Convert.ToString(dbAccLedger.IntAccountType ?? 0) == "4") ? "Begin_Total" : "End_Total",
                    IntIncomeOrBalance = (Convert.ToString(dbAccLedger.IntIncomeOrBalance ?? 0) == "0") ? "Income" : "Balance",
                    intPostingType = (Convert.ToString(dbAccLedger.IntPostingType ?? 0) == "0") ? "" : (Convert.ToString(dbAccLedger.IntPostingType ?? 0) == "1") ? "Debit" : (Convert.ToString(dbAccLedger.IntPostingType ?? 0) == "2") ? "Credit" : "Both",
                    isBlocked = dbAccLedger.IsBlocked ?? false,
                    isPosting = dbAccLedger.IsPosting ?? false,
                    txtAccountName = dbAccLedger.TxtAccountName,
                    txtAccountNumber = dbAccLedger.TxtAccountNumber,
                    intRecID = dbAccLedger.IntRecId

                };
                ViewBag.DeleteStatus = true;
                return View(vwAccountChart);

            }
            catch (Exception e)
            {
                var vwAccountChart = new View_AccountChart();
                return View(vwAccountChart);
            }


           
        }

        [HttpPost]
        public IActionResult Delete(View_AccountChart vmaccledger)
        {
            try {

                var dbaccledger = _dbcontext.TblAccountCharts.Where(x => x.TxtAccountNumber == vmaccledger.txtAccountNumber).SingleOrDefault();
                if (dbaccledger != null)
                {
                    _dbcontext.TblAccountCharts.Remove(dbaccledger);
                    _dbcontext.SaveChanges();
                }
               
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

            
            
        }

        [HttpPost]
        public IActionResult Create(View_AccountChart vmaccledger)
        {
            try {

                if (ModelState.IsValid)
                {
                    var nwAccChart = new TblAccountChart()
                    {
                        TxtAccountName = vmaccledger.txtAccountName,
                        TxtAccountNumber = vmaccledger.txtAccountNumber,
                        IntAccountGroup = Convert.ToInt32(vmaccledger.intAccountGroup),
                        IntAccountType = Convert.ToInt32(vmaccledger.IntAccountType),
                        IntIncomeOrBalance = Convert.ToInt32(vmaccledger.IntIncomeOrBalance),
                        IntPostingType = Convert.ToInt32(vmaccledger.intPostingType),
                        IsBlocked = vmaccledger.isBlocked,
                        IsPosting = vmaccledger.isPosting
                    };

                    _dbcontext.TblAccountCharts.Add(nwAccChart);
                    _dbcontext.SaveChanges();

                }

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

            

        }

        
        public IActionResult Create()
        {
            var vw_accChart = new View_AccountChart();
            try
            {
                var accGroups = _dbcontext.TblAccountGroups.ToList().ConvertAll(x => new SelectListItem
                {
                    Text = x.TxtAccountGroupName,
                    Value = x.IntAccountGroup.ToString()
                });

                vw_accChart.AccountGroups = accGroups;

                return View(vw_accChart);

            }
            catch (Exception e)
            {
                return View(vw_accChart);
            }



        }
    }
}
