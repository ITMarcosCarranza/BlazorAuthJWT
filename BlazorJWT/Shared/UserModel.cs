﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJWT.Shared
{
    public class UserModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
