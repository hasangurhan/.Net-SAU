using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEverNote.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("KullaniciAdi"), Required(ErrorMessage = "{0} alani bos gecileemez"), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmali")]
        public string Username { get; set; }
        [DisplayName("Sifre"), Required(ErrorMessage = "{0} alani bos gecileemez"),DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmali")]
        public string Password { get; set; }
    }
}