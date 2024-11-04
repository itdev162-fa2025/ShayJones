using System;
using Domain; 
using System.Threading.Tasks;
using System.Collections.Generic; 

namespace Persistence {
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Posts.Any())
            {
                var posts = new List<Post>
                {

                    new Post{
                        Title = "First post",
                        Body = "Lorem ipsum dolor sit amet, consectetur ad",
                        Date = DateTime.Now.AddDays(-10)
                    },

                       new Post{
                        Title = "Second post",
                        Body = "Enim neque volupat ad tincidunt vitae sem",
                        Date = DateTime.Now.AddDays(-7)
                    },

                       new Post{
                        Title = "third post",
                        Body = "Imperdiet dui accumsan amet nulla. Ultima",
                        Date = DateTime.Now.AddDays(-4)
                    },
                };

                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
        }
    }
}