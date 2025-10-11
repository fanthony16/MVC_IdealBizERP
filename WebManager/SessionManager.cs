using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace IdealBizUI.WebManager
{
    public class SessionManager
    {
        private static HttpContext _httpContext;
        public SessionManager(HttpContext httpContext)
        {

            _httpContext = httpContext;

        }

        public string GetSessionObject(string name)
        {

            return _httpContext.Session.GetString(name); 

        }

        public bool SaveSessionObject(string _value, string _key)
        {
         
            _httpContext.Session.SetString(_key, _value);
            return true;

        }

        public bool RemoveSessionObject(string _key)
        {

            _httpContext.Session.Remove(_key);
            return true;


        }

        public bool ClearAllSession()
        {
            _httpContext.Session.Clear();
            return true;
        }

    }
}
