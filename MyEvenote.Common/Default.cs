using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvenote.Common
{
    public class Default : ICommon
    {

        public string GetCurrentUserName()
        {
            return "system";
        }
    }
}
