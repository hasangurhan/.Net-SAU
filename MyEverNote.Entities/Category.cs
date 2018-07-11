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
    [Table("Categories")]
   public class Category : MyEntitiyBase
    {   
       [DisplayName("Kategpri"), Required(ErrorMessage ="{0} alani gerekldir"),StringLength(50, ErrorMessage = "{0} alani max {1} karakter içermeli")]
        public string Title { get; set; }

        [DisplayName("Açıklama"),StringLength(150,ErrorMessage = "{0} alani max {1} karakter içermeli")]
        public string Description { get; set; }

        public virtual List<Note> Notes { get; set; }

        public Category()
        {
            Notes = new List<Note>();
        }

    }
}
