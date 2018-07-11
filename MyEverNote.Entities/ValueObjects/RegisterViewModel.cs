using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEverNote.Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("KullaniciAdi"),
            Required(ErrorMessage = "{0} alani bos gecileemez"),
            StringLength(25,ErrorMessage ="{0} max. {1} karakter olmali")]
        public string Username { get; set; }
        [DisplayName("Eposta"), Required(ErrorMessage = "{0} alani bos gecileemez"),
            StringLength(70, ErrorMessage = "{0} max. {1} karakter olmali"),
            EmailAddress(ErrorMessage ="lutfen {0} alanı için geçerli gir")]
        public string Email { get; set; }
        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alani bos gecileemez"),
            DataType(DataType.Password), 
            StringLength(25,ErrorMessage = "{0} max. {1} karakter olmali")]
        public string Password { get; set; }
        [DisplayName("Sifre Tekrar"), 
            Required(ErrorMessage = "{0} alani bos gecileemez"),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} max. {1} karakter olmali"),
            Compare("Password",ErrorMessage = "{0} ile {1} uyuşmuyor")]
        public string RePassword { get; set; }

    }
}