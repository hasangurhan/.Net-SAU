using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.Entities
{
    [Table("Comments")]
    public class Comment : MyEntitiyBase
    {
        [Required,StringLength(300)]
        public string Text { get; set; }

        public virtual Note Note { get; set; }
        public virtual EverNoteUser Owner { get; set; }


    }
}
