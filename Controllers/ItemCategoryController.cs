using IdealBizUI.Data;
using IdealBizUI.Enums;
using IdealBizUI.Models;
using IdealBizUI.QueryManager;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Controllers
{
    public class ItemCategoryController : Controller
    {
        private readonly IdealBizContext _dbcontext;
        

        public ItemCategoryController(IdealBizContext _Idbcontext)
        {

            _dbcontext = _Idbcontext;
            
        }
        public IActionResult Index()
        {
            View_ItemCategory vmitemGroup = new View_ItemCategory();

            try {

                List<TblItemCategory> dbitemCategories = _dbcontext.TblItemCategories.ToList();

                List<ItemCategory> itemGroups = new List<ItemCategory>();
                
                foreach (var i in dbitemCategories)
                {
                    var _ = new ItemCategory
                    {
                         CategoryID = i.IntCategoryId,
                         Code = i.TxtCategoryCode,
                         Description = i.TxtDescription
                    };

                    itemGroups.Add(_);

                };

                vmitemGroup.itemCategories = itemGroups;
                return View(vmitemGroup);

            }
            catch (Exception e)
            {
                return View(vmitemGroup);
            }

        }

        [HttpPost]
        public IActionResult Create(View_ItemCategory nw_itemCategory)
        {
            try
            {

                var _nwItemCategory = new TblItemCategory
                {
                     TxtCategoryCode = nw_itemCategory.itemCategory.Code,
                     TxtDescription = nw_itemCategory.itemCategory.Description
                    
                };

                _dbcontext.TblItemCategories.Add(_nwItemCategory);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }


        }

        public JsonResult GetCategory(int id)
        {
            try
            {

                var _ItemCat = _dbcontext.TblItemCategories.Find(id);
                //string json = JsonConvert.SerializeObject(_usergroup);
                return Json(new { code = _ItemCat.TxtCategoryCode, name = _ItemCat.TxtDescription, id = _ItemCat.IntCategoryId });

            }
            catch (Exception e)
            {
                var _ItemCat = new TblItemCategory();
                return Json(new { code = _ItemCat.TxtCategoryCode, name = _ItemCat.TxtDescription, id = _ItemCat.IntCategoryId });

            }


        }

        [HttpPost]
        public IActionResult Update(View_ItemCategory iCat)
        {

            try
            {

                var dbICAT = _dbcontext.TblItemCategories.Find(iCat.itemCategory.CategoryID);
                dbICAT.TxtCategoryCode = iCat.itemCategory.Code.ToUpper();
                dbICAT.TxtDescription = iCat.itemCategory.Description.ToUpper();
                _dbcontext.TblItemCategories.Update(dbICAT).Property(x => x.IntCategoryId).IsModified = false;
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult DeleteICat(int id)
        {
            try {

                
                var _iCAT = _dbcontext.TblItemCategories.Find(id);
                _dbcontext.Remove(_iCAT);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
            

        }
    }
}
