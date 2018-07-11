using Evernote.Common;
using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            EverNoteUser user = CurrentSession.User;
            if (user!=null)
            {
                return user.Username;
            }
            else
            return "system";
        }
    }
}