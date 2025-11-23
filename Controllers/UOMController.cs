using IdealBizUI.Data;
using IdealBizUI.InterfaceServices;
using IdealBizUI.Models;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Controllers
{
    public class UOMController : Controller
    {
        private readonly IUserManager _uManager;
        private readonly IdealBizContext _dbcontext;

        public UOMController(IUserManager _Manager, IdealBizContext _Idbcontext)
        {
            _uManager = _Manager;
            _dbcontext = _Idbcontext;
        }
        public IActionResult Index()
        {
            View_UnitOfMeasure vwUOM = new View_UnitOfMeasure();
            try {

                List<TblUnitOfMeasure> dbUOMS = _dbcontext.TblUnitOfMeasures.ToList();
                List<UnitOfMeasure> _UOMS = new List<UnitOfMeasure>();
                
                foreach (var uom in dbUOMS)
                {
                    var _ = new UnitOfMeasure
                    {

                        UoMID = uom.IntUnitOfMeasure,
                        Code = uom.TxtUomcode,
                        Description = uom.TxtDesciption

                    };

                    _UOMS.Add(_);

                };

                vwUOM.UnitOfMeasures = _UOMS;

                return View(vwUOM);

            }
            catch (Exception e)
            {
                return View(vwUOM);
            }

            

            
        }

        [HttpGet]
        public IActionResult Create()
        {

            var UOMs = new UnitOfMeasure();
            return View(UOMs);

        }
        [HttpPost]
        public IActionResult Create(View_UnitOfMeasure vwUOM)
        {

            try
            {
                var _nwUOM = new TblUnitOfMeasure
                {
                    TxtUomcode = vwUOM.UnitOfMeasure.Code.ToUpper(),
                    TxtDesciption = vwUOM.UnitOfMeasure.Description.ToUpper()
                };

                _dbcontext.TblUnitOfMeasures.Add(_nwUOM);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        public JsonResult GetUOM(int id)
        {
            try {

                var _UOM = _dbcontext.TblUnitOfMeasures.Find(id);
                //string json = JsonConvert.SerializeObject(_usergroup);
                return Json(new { code = _UOM.TxtUomcode, name = _UOM.TxtDesciption, id = _UOM.IntUnitOfMeasure });

            }
            catch (Exception e)
            {
                var _UOM = new TblUnitOfMeasure();
                return Json(new { code = _UOM.TxtUomcode, name = _UOM.TxtDesciption, id = _UOM.IntUnitOfMeasure });
            }
            

        }


        [HttpPost]
        public IActionResult Update(View_UnitOfMeasure uom)
        {

            try {

                var dbUOM = _dbcontext.TblUnitOfMeasures.Find(uom.UnitOfMeasure.UoMID);
                dbUOM.TxtUomcode = uom.UnitOfMeasure.Code.ToUpper();
                dbUOM.TxtDesciption = uom.UnitOfMeasure.Description.ToUpper();

                _dbcontext.TblUnitOfMeasures.Update(dbUOM).Property(x => x.IntUnitOfMeasure).IsModified = false;
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
           
        }

        public IActionResult DeleteUOM(int id)
        {

            var _uom = _dbcontext.TblUnitOfMeasures.Find(id);
            _dbcontext.Remove(_uom);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
