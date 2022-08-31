﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeToSell.Data.Entity
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}