using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManager
{
    public class Shopper
    {        
        public int Id;
        public DateTime joinTime;
        
        public Shopper(int id)
        {
            Id = id;
            joinTime = DateTime.Now;
        }
    }
    public class Cashier:Object
    {
        public int Id;
        public Cashier(int id)
        {
            Id = id;
        }
    }
}
