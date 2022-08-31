using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToSell.Common
{
    public class TimeToSellSettings
    {
        public DatabaseConfiguration Database { get; set; }

        public class DatabaseConfiguration
        {
            public string ConnectionString { get; set; }
        }
    }
}