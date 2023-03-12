using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Helper
{
    public static class GenerateActiveCode
    {
        public static string GenarateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
