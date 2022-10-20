using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_CODAPI
{
    public static class CODAPI
    {
        public static bool login(string ssoToken) => Http.login(ssoToken);
        public static MW mw = new();
    }
}
