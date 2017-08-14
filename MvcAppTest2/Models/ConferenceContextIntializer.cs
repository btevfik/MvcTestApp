using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcAppTest2.Models
{
    public class ConferenceContextIntializer : DropCreateDatabaseAlways<ConferenceContext>
    {
        protected override void Seed(ConferenceContext context)
        {
            context.Sessions.Add(
                new Session()
                {
                    Title = "I want spagetti",
                    Abstract = "The life and times of a spagetti lover",
                    Speaker = context.Speakers.Add(new Speaker()
                    {
                        Name = "Baris TEVFIK",
                        EmailAdd = "Baris@yahoo.com",
                        BirthDay = new DateTime(1990, 12, 12)
                    }),
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Content="This is a comment and its awesome. -baris"
                        },
                        new Comment()
                        {
                            Content="Comment number 2."
                        }
                    }
                });
            context.SaveChanges();
        }
    }
}