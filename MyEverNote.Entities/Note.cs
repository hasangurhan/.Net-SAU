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
    [Table("Notes")]
    public class Note : MyEntitiyBase
    {
        [DisplayName("Not Basligi"),Required, StringLength(60)]
        public string Title { get; set; }
        [DisplayName("Not metni"),Required, StringLength(2000)]
        public string Text { get; set; }
        [DisplayName("Taslak")]
        public bool IsDraft { get; set; }
        [DisplayName("Beğenilme")]
        public int LikeCount { get; set; }
        [DisplayName("Kategori Basliği")]
        public int CategoryId { get; set; }

        public virtual EverNoteUser Owner { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Commnets { get; set; }
        public virtual List<Liked> Likes { get; set; }
        public Note()
        {
            Commnets = new List<Comment>();
            Likes = new List<Liked>();
        }

    }
}
