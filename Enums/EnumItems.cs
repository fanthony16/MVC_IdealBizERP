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

        public enum ItemType
        {
            Inventory = 0,
            Service = 1,
            Non_Inventory = 2
        }
        public enum CostingMethod
        {
            Standard = 1,
            FIFO = 2,
            LIFO = 3,
            Specific = 4,
            Average = 5
        }

        public enum ReplenishType
        {
            Purchase = 1 ,
            Prod_Order = 2,
            Assempbly = 3
        }

        public enum AccountType
        {
            Posting =1,
            Heading = 2,
            Total = 3,
            Begin_Total = 4,
            End_Total = 5
        }

        public enum PostingType
        {
            Debit = 1,
            Credit = 2,
            Both = 3
        }
        public enum AccountClass
        {
            Income = 0,
            Balance = 1
        }
    }
}
