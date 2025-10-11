using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.Enums
{
    public class EnumItems
    {
        public enum EManager
        {
            Default = 0,
            Sales = 1,
            Manager = 2,
            Admin = 3
        }

        public enum ESupervisor
        {
            Male = 1,
            Female = 0,
            Others = 2
        }
    }
}
