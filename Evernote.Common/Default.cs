using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.Common
{
    class Default : ICommon
    {
        public string GetCurrentUsername()
        {
            return "system";
        }
    }
}
