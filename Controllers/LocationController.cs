using IdealBizUI.Data;
using IdealBizUI.Models;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Controllers
{
    public class LocationController : Controller
    {
        private readonly IdealBizContext _dbcontext;


        public LocationController(IdealBizContext _Idbcontext)
        {

            _dbcontext = _Idbcontext;

        }
        public IActionResult Index()
        {

            View_Location vmLocation = new View_Location();
            try
            {
                List<TblLocation> dbLocations = _dbcontext.TblLocations.ToList();
                List<Location> locations = new List<Location>();
                foreach (var i in dbLocations)
                {
                    var _ = new Location
                    {
                         LocationID = i.IntLocation,
                         Name = i.TxtName,
                         Code = i.TxtCode
                    };
                    locations.Add(_);
                };
                vmLocation.ItemLocations = locations;
                return View(vmLocation);
            }
            catch (Exception e)
            {
                return View(vmLocation);
            }

            

        }

        public IActionResult Create(View_Location nw_location)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var _nwLocation = new TblLocation
                    {
                        TxtCode = nw_location.ItemLocation.Code,
                        TxtName = nw_location.ItemLocation.Name
                    };

                    _dbcontext.TblLocations.Add(_nwLocation);
                    _dbcontext.SaveChanges();

                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult Update(View_Location _Location)
        {

            try
            {

                var dbLocation = _dbcontext.TblLocations.Find(_Location.ItemLocation.LocationID);
                dbLocation.TxtCode = _Location.ItemLocation.Code.ToUpper();
                dbLocation.TxtName = _Location.ItemLocation.Name.ToUpper();
                _dbcontext.TblLocations.Update(dbLocation).Property(x => x.IntLocation).IsModified = false;
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

        }


        public JsonResult GetLocation(int id)
        {
            try
            {

                var _Location = _dbcontext.TblLocations.Find(id);
                //string json = JsonConvert.SerializeObject(_usergroup);
                return Json(new { code = _Location.TxtCode, name = _Location.TxtName, id = _Location.IntLocation });

            }
            catch (Exception e)
            {
                var _Location = new TblLocation();
                return Json(new { code = _Location.TxtCode, name = _Location.TxtName, id = _Location.IntLocation });

            }


        }

        public IActionResult DeleteLocation(int id)
        {
            try
            {

                var _location = _dbcontext.TblLocations.Find(id);
                _dbcontext.Remove(_location);
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
