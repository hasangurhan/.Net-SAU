using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEverNote.Entities;

namespace MyEverNote.AccessLayer.EntitiyFramework
{
    public class MyInitializer: CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            //adding admin user
            EverNoteUser admin = new EverNoteUser()
            {
                Name = "hasan",
                Surname = "gurhan",
                Email = "nyksv@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActivite = true,
                Username = "hasangurhan",
                ProfileImageFilename = "User.png",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "hasangurhan"


            };
            //adding standart user
            EverNoteUser standartUser = new EverNoteUser()
            {
                Name = "ipsadsadek",
                Surname = "gurhsadasdan",
                Email = "nydksv@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActivite = true,
                Username = "ipekgurhan",
                ProfileImageFilename = "User.png",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "ipekgurhan"


            };
            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(standartUser);
            for (int i = 0; i < 8; i++)
            {
                EverNoteUser user = new EverNoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActivite = true,
                    Username = $"user{i}",
                    ProfileImageFilename = "User.png",
                    Password = "123456",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}",


                };
                context.EvernoteUsers.Add(user);
            }
        
            context.SaveChanges();
            //userlist for using ...
            List<EverNoteUser> userlist = context.EvernoteUsers.ToList();
            // fake data categories
            for (int i= 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "hasangurhan"

                };
                context.Categories.Add(cat);
                //adding fake notes
                for (int k = 0;  k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    EverNoteUser owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];

                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        Category = cat,
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.Username,

                    };
                    cat.Notes.Add(note);
                    //adding fake comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        EverNoteUser comment_owner = userlist[FakeData.NumberData.GetNumber(0, userlist.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username,

                        };
                        note.Commnets.Add(comment);
                    }
                        //adding fake like
                       
                        for (int m = 0; m < note.LikeCount; m++)
                        {
                            Liked liked = new Liked()
                            {
                                LikedUser = userlist[m]
                            };
                            note.Likes.Add(liked);
                        }
                }
            }
            context.SaveChanges();
        }
    }
}
