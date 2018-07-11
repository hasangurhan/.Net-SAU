using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class WarningViewModel : NotifiyViewModelBase<string>
    {
        public WarningViewModel()
        {
            Title = "Uyarı 1 !";
        }
    }
}