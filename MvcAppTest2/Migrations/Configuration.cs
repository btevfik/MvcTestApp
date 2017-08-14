namespace MvcAppTest2.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcAppTest2.Models.ConferenceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcAppTest2.Models.ConferenceContext";
        }

        protected override void Seed(MvcAppTest2.Models.ConferenceContext context)
        {
            context.Sessions.AddOrUpdate(
               new Session()
               {
                   Title = "MVC Test Session (migration seed)",
                   Abstract = "This is about testing MVC (migration seed)",
                   Speaker = context.Speakers.Add(new Speaker()
                   {
                       Name = "Baris Tevfik (migration seed)",
                       EmailAdd = "baristevfik@example.com",
                       BirthDay = new DateTime(1990, 12, 12)
                   }),
                   Comments = new List<Comment>()
                   {
                        new Comment()
                        {
                            Content="This is a comment. (migration seed)"
                        },
                        new Comment()
                        {
                            Content="This is number two comment. (migration seed)"
                        }
                   }
               });
            context.SaveChanges();
        }
    }
}
