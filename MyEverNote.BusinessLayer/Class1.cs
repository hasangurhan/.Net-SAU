using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEverNote.AccessLayer.EntitiyFramework;

namespace MyEverNote.BusinessLayer
{
    public class Class1
    {
        private Repository<EverNoteUser> repo_user = new Repository<EverNoteUser>();
        private Repository<Category> repo = new Repository<Category>();
        private Repository<Comment> repo_comment = new Repository<Comment>();
        private Repository<Note> repo_note = new Repository<Note>();
        public Class1()
        {
            List<Category> categories = repo.List();
           // List<Category> categories_filtered = repo.List(x=>x.Id>5);
        }
        public void InsertTest()
        {
            
            int result = repo_user.Insert(new EverNoteUser()
            {
                Name = "ipsadsadek",
                Surname = "gurhsadasdan",
                Email = "nydksv@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActivite = true,
                Username = "aabb",
                Password = "111",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "aabb"
            });
        }
        public void UptadeTest()
        {
            EverNoteUser user = repo_user.Find(x => x.Username == "aabb");
            if (user != null)
            {
                user.Username = "xxx";
                int result = repo_user.Update(user);
            }
        }
        public void DeleteTest()
        {
            EverNoteUser user = repo_user.Find(x => x.Username == "xxx");
                if (user != null)
            {
                int result=repo_user.Delete(user);
            }
        }
        public void CommentTest()
        {
            EverNoteUser user = repo_user.Find(x => x.Id == 1);
            Note note = repo_note.Find(x => x.Id == 3);
            Comment comment = new Comment()
            {
                Text = "Bu bir testtir",
                CreatedOn = DateTime.Now,
                ModifiedOn=DateTime.Now,
                ModifiedUsername="hsanagurhan",
                Note=note,
                Owner=user
            };
            repo_comment.Insert(comment);
                
        }


    }
}
