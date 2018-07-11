using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class OkViewModel : NotifiyViewModelBase<string>
    {
        public OkViewModel()
        {
            Title = " İşlem Başarılı";
        }
    }
}