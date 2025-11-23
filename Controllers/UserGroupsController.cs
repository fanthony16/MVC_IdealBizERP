using IdealBizUI.Data;
using IdealBizUI.Models;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using IdealBizUI.QueryManager;

namespace IdealBizUI.Controllers
{
    public class UserGroupsController : Controller
    {
        
        private readonly IdealBizContext _dbcontext;
        private readonly CodeUnits _codeUnit;

        public UserGroupsController(IdealBizContext _Idbcontext, CodeUnits codeUnit)
        {
           
            _dbcontext = _Idbcontext;
            _codeUnit = codeUnit;

        }

        public IActionResult Index()
        {          

            List<TblUserGroup> dbuserGroups = _dbcontext.TblUserGroups.ToList();
            List<UserGroup> userGroups = new List<UserGroup>();
            View_UserGroup vmuserGroup = new View_UserGroup();


            foreach (var i in dbuserGroups)
            {
                var _ = new UserGroup
                {
                   AccessGroupID = i.IntAccessGroup,
                   GroupCode = i.TxtGroupCode,
                   GroupName = i.TxtGroupName

                };

                userGroups.Add(_);

            };

            vmuserGroup.UserGroups = userGroups;
            return View(vmuserGroup);


            
        }

        public JsonResult GetUserGroup(string id)
        {

            var _usergroup = _dbcontext.TblUserGroups.Find(id);
            //string json = JsonConvert.SerializeObject(_usergroup);
            return Json(new { name = _usergroup.TxtGroupName, code = _usergroup.TxtGroupCode });

        }

        public IActionResult DeleteUserGroup(string id)
        {

            var _usergroup = _dbcontext.TblUserGroups.Find(id);
            _dbcontext.Remove(_usergroup);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Create(View_UserGroup nw_user_group)
        {
            try {

                var _nwUserGroup = new TblUserGroup
                {
                    TxtGroupName = nw_user_group._UserGroup.GroupName,
                    TxtGroupCode = _codeUnit.getCode("UserGroup")
                };

                _dbcontext.TblUserGroups.Add(_nwUserGroup);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
           

        }

        [HttpPost]
        public IActionResult Update(View_UserGroup nw_user_group)
        {

            var dbUserGroup = _dbcontext.TblUserGroups.Find(nw_user_group._UserGroup.GroupCode);
            dbUserGroup.TxtGroupName = nw_user_group._UserGroup.GroupName;

            _dbcontext.TblUserGroups.Update(dbUserGroup).Property(x => x.IntAccessGroup).IsModified = false;
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");

        }

       





    }

    
}
