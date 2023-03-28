using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorJWT.Shared
{
    public class LoginResult
    {
        public string Token { get; set; }

        public bool isValid { get; set; }

        public string Error { get; set; }
    }
}
