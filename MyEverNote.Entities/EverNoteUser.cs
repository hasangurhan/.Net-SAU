using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.Entities
{
    [Table("EverNoteUsers")]
    public class EverNoteUser : MyEntitiyBase
    {
        [DisplayName("İsim"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }
        [DisplayName("Soyad"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }
        [DisplayName("KullaniciAdi"),
            Required(ErrorMessage ="{0} alanı gereklidir"),StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Username { get; set; }
        [DisplayName("Eposta"),
            Required(ErrorMessage = "{0} alanı gereklidir"), StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }
        [DisplayName("Sifree"),
            Required(ErrorMessage = "{0} alanı gereklidir"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
         public string Password { get; set; }

        [DisplayName("Aktif")]
        public bool IsActivite { get; set; }
        [DisplayName("Yönetici")]
        public bool IsAdmin { get; set; }

        [StringLength(30),ScaffoldColumn(false)]
        public string ProfileImageFilename { get; set; }
        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }
      

        public virtual List<Note> Notes { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }


    }
}
