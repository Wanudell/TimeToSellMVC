using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToSell.Common
{
    public class TimeToSellDbContext : DbContext
    {
        public TimeToSellDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}