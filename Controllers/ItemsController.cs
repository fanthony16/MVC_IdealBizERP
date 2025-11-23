using IdealBizUI.Data;
using IdealBizUI.QueryManager;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace IdealBizUI.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IdealBizContext _dbcontext;
        private readonly CodeUnits _codeunit;


        public ItemsController(IdealBizContext _Idbcontext, CodeUnits codeUnit)
        {
            _dbcontext = _Idbcontext;
            _codeunit = codeUnit;
        }

        public IActionResult Index()
        {

            List<TblItem> _dbItems = _dbcontext.TblItems.ToList();
            List<View_Items> _items = new List<View_Items>();

            foreach (var itm in _dbItems)
            {
                var _ = new View_Items()
                {
                    ItemID = itm.IntItemId,
                    ItemCode = itm.TxtItemCode,
                    ItemName = itm.TxtItemName,
                    BaseUnitOfMeasure = itm.TxtBaseUnitOfMeasure,
                    PuchaseUnitOfMeasure = itm.TxtPurchUnitOfMeasure,
                    SalesUnitOfMeasure = itm.TxtSalesUnitOfMeasure,
                    CostingMethod = itm.TxtCostingMethod,
                    GeneralProductPostingGroup = itm.TxtGeneralProductPostingGroup,
                    InventoryPostingGroup = itm.TxtInventoryPostingGroup,
                    AllowInvoiceDiscount  = itm.BlnAllowInvoiceDiscount?? false,
                    VATProductPostingGroup = itm.TxtVatproductPostingGroup,
                    ReplenishSystem = itm.TxtReplenishSystem,
                    ItemBlocked = itm.BlnBlocked ?? false,
                    ShelfNo = itm.TxtShelfNo,
                    IndirectCost = itm.NumIndirectCost,
                    ItemType = (Convert.ToString(itm.IntItemType) == "0")? "Inventory" : (Convert.ToString(itm.IntItemType) == "1") ? "Service" : "Non_Inventory",
                    UnitCost = itm.NumUnitCost,
                    PurchaseBlocked = itm.BtnPurchaseBlocked ?? false,
                    PurchaseVendor = itm.TxtPurchaseVendor,
                    SalesBlocked = itm.BlnSalesBlocked ?? false,
                    SellingPrice = itm.NumSellingPrice,
                    StandardCost = itm.NumStandardCost,
                    CategoryID = itm.IntCategoryId

                };


                

                _items.Add(_);
            }

            return View(_items);

        }
        
        public IActionResult Create()
        {

            try {

                var unitofmeasures = _dbcontext.TblUnitOfMeasures.ToList().ConvertAll(x => new SelectListItem
                {
                    Text = x.TxtDesciption,
                    Value = x.TxtUomcode
                });


                var itemcategory = _dbcontext.TblItemCategories.ToList().ConvertAll(x => new SelectListItem
                {
                    Text = x.TxtDescription,
                    Value = Convert.ToString(x.IntCategoryId)
                });


                var vmItem = new View_Items
                {
                    ItemCode = _codeunit.getCode("Item"),
                    UnitOfMeasures = unitofmeasures,
                    ItemsCategories = itemcategory
                };


                return View(vmItem);

            }
            catch (Exception e)
            {
                var vmItem = new View_Items();
                return View(vmItem);
            }

            
        }
        [HttpPost]
        public IActionResult Create(View_Items itm)
        {           
            
            var nwItem = new TblItem
            {
                TxtItemCode = itm.ItemCode,
                TxtItemName = itm.ItemName,
                BlnAllowInvoiceDiscount = itm.AllowInvoiceDiscount,
                BlnBlocked = itm.ItemBlocked,
                BlnSalesBlocked = itm.SalesBlocked,
                BtnPurchaseBlocked = itm.PurchaseBlocked,
                IntCategoryId = itm.CategoryID,
                IntCompany = 1,
                NumIndirectCost = itm.IndirectCost,
                NumSellingPrice = itm.SellingPrice,
                NumStandardCost = itm.StandardCost,
                NumUnitCost = itm.UnitCost,
                TxtBaseUnitOfMeasure = itm.BaseUnitOfMeasure,
                TxtCostingMethod = itm.CostingMethod,
                TxtGeneralProductPostingGroup = itm.GeneralProductPostingGroup,
                IntItemType = Convert.ToInt32(itm.ItemType),
                TxtInventoryPostingGroup = itm.InventoryPostingGroup,
                TxtPurchaseVendor = itm.PurchaseVendor,
                TxtPurchUnitOfMeasure = itm.PuchaseUnitOfMeasure,
                TxtVatproductPostingGroup = itm.VATProductPostingGroup,
                TxtReplenishSystem = itm.ReplenishSystem,
                TxtSalesUnitOfMeasure = itm.SalesUnitOfMeasure,
                TxtShelfNo = itm.ShelfNo
            };


            if (itm.ItemFile != null || itm.ItemFile.Length != 0)
            {
                var filePath = Path.Combine("~/Images/ItemImages", itm.ItemFile.FileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    itm.ItemFile.CopyTo(stream);
                }
                nwItem.ImagePath = filePath;
            }

            _dbcontext.Add(nwItem);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(string id)
        {
            var unitofmeasures = _dbcontext.TblUnitOfMeasures.ToList().ConvertAll(x => new SelectListItem
            {
                Text = x.TxtDesciption,
                Value = x.TxtUomcode
            });


            var itemcategory = _dbcontext.TblItemCategories.ToList().ConvertAll(x => new SelectListItem
            {
                Text = x.TxtDescription,
                Value = Convert.ToString(x.IntCategoryId)
            });

            var dbItem = _dbcontext.TblItems.FirstOrDefault(x => x.TxtItemCode == id);

            var _ = new View_Items
            {

                ItemID = dbItem.IntItemId,
                ItemCode = dbItem.TxtItemCode,
                ItemName = dbItem.TxtItemName,
                IndirectCost = dbItem.NumIndirectCost,
                InventoryPostingGroup = dbItem.TxtInventoryPostingGroup,
                ItemBlocked = dbItem.BlnBlocked ?? false,
                ItemType = dbItem.IntItemType.ToString(),
                AllowInvoiceDiscount = dbItem.BlnAllowInvoiceDiscount ?? false,
                BaseUnitOfMeasure = dbItem.TxtBaseUnitOfMeasure,
                PuchaseUnitOfMeasure = dbItem.TxtPurchUnitOfMeasure,
                SalesUnitOfMeasure = dbItem.TxtSalesUnitOfMeasure,
                CostingMethod = dbItem.TxtCostingMethod,
                CategoryID = dbItem.IntCategoryId,
                GeneralProductPostingGroup = dbItem.TxtGeneralProductPostingGroup,
                PurchaseBlocked = dbItem.BtnPurchaseBlocked ?? false,
                PurchaseVendor = dbItem.TxtPurchaseVendor,
                ReplenishSystem = dbItem.TxtReplenishSystem,
                SalesBlocked = dbItem.BlnSalesBlocked ?? false,
                SellingPrice = dbItem.NumSellingPrice,
                StandardCost = dbItem.NumStandardCost,
                VATProductPostingGroup = dbItem.TxtVatproductPostingGroup,
                ShelfNo = dbItem.TxtShelfNo,
                UnitCost = dbItem.NumUnitCost,
                ItemsCategories = itemcategory,
                UnitOfMeasures = unitofmeasures,
                ImagePath =  dbItem.ImagePath ?? "~/images/ItemImages/Default.PNG"

            };

            return View(_);

        }

        [HttpPost]
        public IActionResult Edit(View_Items itm)
        {

            try {

                var dbItem = _dbcontext.TblItems.FirstOrDefault(x => x.TxtItemCode == itm.ItemCode);

                if (dbItem != null)
                {

                    dbItem.TxtItemName = itm.ItemName;
                    dbItem.BlnAllowInvoiceDiscount = itm.AllowInvoiceDiscount;
                    dbItem.BlnBlocked = itm.ItemBlocked;
                    dbItem.BlnSalesBlocked = itm.SalesBlocked;
                    dbItem.BtnPurchaseBlocked = itm.PurchaseBlocked;
                    dbItem.IntCategoryId = itm.CategoryID;
                    dbItem.IntCompany = 1;
                    dbItem.NumIndirectCost = itm.IndirectCost;
                    dbItem.NumSellingPrice = itm.SellingPrice;
                    dbItem.NumStandardCost = itm.StandardCost;
                    dbItem.NumUnitCost = itm.UnitCost;
                    dbItem.TxtBaseUnitOfMeasure = itm.BaseUnitOfMeasure;
                    dbItem.TxtCostingMethod = itm.CostingMethod;
                    dbItem.TxtGeneralProductPostingGroup = itm.GeneralProductPostingGroup;
                    dbItem.IntItemType = Convert.ToInt32(itm.ItemType);
                    dbItem.TxtInventoryPostingGroup = itm.InventoryPostingGroup;
                    dbItem.TxtPurchaseVendor = itm.PurchaseVendor;
                    dbItem.TxtPurchUnitOfMeasure = itm.PuchaseUnitOfMeasure;
                    dbItem.TxtVatproductPostingGroup = itm.VATProductPostingGroup;
                    dbItem.TxtReplenishSystem = itm.ReplenishSystem;
                    dbItem.TxtSalesUnitOfMeasure = itm.SalesUnitOfMeasure;
                    dbItem.TxtShelfNo = itm.ShelfNo;

                    if (itm.ItemFile != null || itm.ItemFile.Length != 0)
                    {

                        if (System.IO.File.Exists(dbItem.ImagePath))

                        {

                            System.IO.File.Delete(dbItem.ImagePath);

                        }

                        var fileName = Path.GetFileNameWithoutExtension(itm.ItemFile.FileName);
                        var fileExtension = Path.GetExtension(itm.ItemFile.FileName);
                        var fullPath = Path.Combine(Path.GetFullPath("./wwwroot/") + "Images\\ItemImages\\", fileName + fileExtension);
                        string db_filePath = "";
                        

                        try {

                            if (System.IO.File.Exists(fullPath))
                            {
                                System.IO.File.Delete(fullPath);
                            }

                            using (var stream = System.IO.File.Create(fullPath))
                            {

                                itm.ItemFile.CopyTo(stream);

                            }
                            db_filePath = "~/Images/ItemImages/" + fileName + fileExtension;
                        }
                        catch (Exception e)
                        {
                            db_filePath = "";
                        }

                        

                        dbItem.ImagePath = db_filePath;

                    }

                    _dbcontext.Update(dbItem);
                    _dbcontext.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}
