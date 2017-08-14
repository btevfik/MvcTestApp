using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcAppTest2.Models
{
    public class ConferenceContextIntializer : CreateDatabaseIfNotExists<ConferenceContext>
    {
        protected override void Seed(ConferenceContext context)
        {
            context.Sessions.Add(
                new Session()
                {
                    Title = "MVC Test Session",
                    Abstract = "This is about testing MVC",
                    Speaker = context.Speakers.Add(new Speaker()
                    {
                        Name = "Baris Tevfik",
                        EmailAdd = "baristevfik@example.com",
                        BirthDay = new DateTime(1990, 12, 12)
                    }),
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Content="This is a comment."
                        },
                        new Comment()
                        {
                            Content="This is number two comment."
                        }
                    }
                });
            context.SaveChanges();
        }
    }
}