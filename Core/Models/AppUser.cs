﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
