using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using SportsStore.Models.ViewModels;
using System.Runtime.InteropServices;

namespace SportsStore.Models
{
    public class SeedData
    {
       

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
          
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
               
                context.Products.AddRange(
                    new Product
                    {
                        Name = "One Piece - Dao Hai Tac",
                        
                        Author = " Oda Eiichiro",
                        Description = "One Piece (ワンピース Wan Pīsu?), once published in Vietnam under the name Pirate Island is a manga series for teenagers by author Oda Eiichiro, serialized in Weekly Shōnen Jump magazine. It was first published in issue 34 on July 19, 1997. The tankōbon version of the manga was published by Shueisha with the first volume on December 24, 1997. One Piece follows the journey of Monkey D. Luffy - the captain. of the Straw Hat Pirates and his comrades. Luffy searches the mysterious sea where the world's greatest treasure, One Piece, is kept, with the goal of becoming the New Pirate King.",
                        Category = "Manga",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Alchemist",
                        Image = "Book2.jpg",
                        Author = "Paulo Coelho",
                        Description = "The Alchemist by Paulo Coelho is a great book for those who have lost their dreams or have never formed their own. If you are looking for books to read to change your life, The Alchemist is a good suggestion.",
                        Category = "Novel",
                        Price = 48.95m
                    },
                     new Product
                     {
                         Name = "Life changes when we change",
                         Image= "/Image/Book.jpg",
                         Author = "Andrew Matthews",
                         Description = "Life changes when we change (Being A Happy Teenager) by Andrew Matthews gives readers real situations, even stories that are \"small\" but equally \"important\" with how they respond. In addition, when reading this book, readers will see their own life in it, the competition, failure, and even very honest communication situations. and useful. This is a good book that everyone should read once in their life to change their life, especially for those who have a negative lifestyle, this is a perfect suggestion.",
                         Category = "Life",
                         Price = 19.50m
                     },
                     new Product
                     {
                         Name = "Naruto",
                         Image = "Book4.jpg",
                         Author = "Tons",
                         Description = "Naruto is a Japanese manga series written and illustrated by Masashi Kishimoto. It tells the story of Naruto Uzumaki, a young ninja who seeks recognition from his peers and dreams of becoming the Hokage, the leader of his village.",
                         Category = "Manga",
                         Price = 34.95m
                     },
                     new Product
                     {
                         Name = "Noble hearts",
                         Image = "Book5.jpg",
                         Author = " Edmondo De Amicis",
                         Description = "The book The Great Hearts of the famous Italian writer - Edmondo De Amicis has content revolving around the ordinary life of a boy and is equally touching. His simple and innocent feelings are reflected in the way he behaves with his teachers, parents, and classmates, and also in the way he describes them full of innocence and love. love.",
                         Category = "Life",
                         Price = 79.5m
                     },
                     new Product
                     {
                         Name = "Read anyone",
                         Image = "Book6.jpeg",
                         Author = "David J.Lieberman",
                         Description = "Read Anyone's Place is a handbook that teaches you how to get into other people's minds to know what they're thinking. This book will not help you draw general conclusions about someone based on feelings or subjective speculation. The principles shared in this book are not merely theories or tricks that are only true under certain circumstances or with certain audiences.",
                         Category = "Mentality",
                         Price = 26.6m
                     },
                     new Product
                     {
                         Name = "7 Habits for Success",
                         Image = "",
                         Author = "Stephen R. Covey",
                         Description = "7 Habits of Success is one of the most famous books in the world that is loved by many people. This book was written by Stephen R. Covey - one of the experts in the field of leadership development and culture creation and one of the 25 most influential people in America. Published in 1989, but until now the values and valuable lessons from the book are still intact in the hearts of readers.",
                         Category = "Life",
                         Price = 29.95m
                     },
                     new Product
                     {
                         Name = "Little Women",
                         Image = "/Image/Book1.png",
                         Author = "Louisa May Alcott",
                         Description = "In the 19th century, the novel \"Little Girls\" once caused a fever at home and then spread around the world. Little Women, a book that seemed to be all about \"ordinary girls\" in a not-so-well-off family, has become a story that spans generations of readers. Millions of millions of female readers around the world have found themselves in the story of four sisters Meg, Jo, Beth, and Amy.",
                         Category = "Novel",
                         Price = 75m
                     },
                     new Product
                     {
                         Name = "For Whom the Bell Tolls",
                         Image  ="",
                         Author = "Ernest Hemingway",
                         Description = "For Whom the Bell Tolls, although it is a dry realistic work, is not boring. The book is very thick, but the story takes place in just under three days, enough to see how Ernest Hemingway put all his heart to write truthfully and completely. Maybe at first you will feel bored and a bit bland, but the more you read, the more you will be absorbed in the work so that when you close the book, you will still be lost for a long time out of your thoughts. Read it and feel the war and the pain and loss it brings to humanity!",
                         Category = "Story",
                         Price = 32.5m
                     }
                    );
                context.SaveChanges();
            }
        }
    }
}