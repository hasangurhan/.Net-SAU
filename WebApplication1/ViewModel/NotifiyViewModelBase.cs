using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class NotifiyViewModelBase<T>
    {
        public List<T> Items { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public bool IsRedirecting { get; set; }
        public string RedirectingUrl { get; set; }
        public int RedirectingTimeout { get; set; }
        public NotifiyViewModelBase()
        {
            Header = "yönlendiriliyorsunuz";
            Title = "Geçersiz işlem";
            IsRedirecting = true;
            RedirectingUrl = "/Home/Index";
            RedirectingTimeout = 3000;
            Items = new List<T>();
        }
    }
}