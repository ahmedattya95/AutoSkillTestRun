using AutoskillTestRun. Models;
using System. Collections. Generic;
using System.Linq;
using Xamarin.Forms;

namespace AutoskillTestRun. Services
{
	/// <summary>
    /// Mock Database Service
    /// </summary>
	public class DatabaseService: IDatabaseService
    {
		private List<Contact> contacts;
		private List<Quote> quotes;
        private List<Article> articles;


        public DatabaseService ()
        {
			contacts = InitContacts ();
			quotes = InitQuotes ();
            articles = IntiArticles();
        }
  

		public void UpdateContact(Contact contact)
		{
			if (contact.Id == 0) {
				contact. Id = contacts. Count + 1;
				contacts. Add ( contact );
			}
			else {
				var oldContact = contacts. Find ( c => c. Id == contact. Id );
				oldContact. Name = contact. Name;
				oldContact. Phone = contact. Phone;
			}
		}


		public void UpdateQuote(Quote quote)
		{
			if (quote.Id == 0) {
				quote. Id = quotes. Count + 1;
				quotes. Add ( quote );
			}
			else {
				var oldQuote = quotes. Find ( q => q. Id == quote. Id );
				oldQuote. CustomerName = quote. CustomerName;
				oldQuote. Total = quote. Total;
			}
		}

        
        public List<Contact> GetContacts ()
        {
			return contacts;
        }


        public List<Quote> GetQuotes ()
        {
			return quotes;
        }


		private List<Contact> InitContacts ()
        {
            return new List<Contact> {
                new Contact { Id = 1, Name = "Xam Consulting", Phone = "0404 865 350" },
                new Contact { Id = 2, Name = "Michael Ridland", Phone = "0404 865 350" },
                new Contact { Id = 3, Name = "Thunder Apps", Phone = "0404 865 350" },
            };
        }


        private List<Quote> InitQuotes ()
        {
            return new List<Quote> {
                new Quote { Id = 1, CustomerName = "Xam Consulting", Total = "$350.00" },
                new Quote { Id = 2, CustomerName = "Michael Ridland", Total = "$3503.00" },
                new Quote { Id = 3, CustomerName = "Thunder Apps", Total = "$3504.00" },
            };
        }


        private List<Article> IntiArticles()
        {
            return new List<Article>
            {
                new Article
                {
                    ID = 1,
                    Title = "Welcome to Xamarin.Forms",
                    Body = "Hey there try Xamarin.Forms 3, It contains a lot of cool features that will help you to build amazing apps in different domains",
                    CoverImage = ImageSource.FromFile("xamarinforms.jpg")
                }
                , new Article
                {
                    ID = 2,
                    Title = "Cool CrossPlatform Apps",
                    Body = "With Xamarin.Forms you can build Android, iOS and Windows Apps with up to 90% shared code between all platforms",
                    CoverImage = ImageSource.FromFile("crossplatform.jpg")
                }
                , new Article
                {
                    ID = 3,
                    Title = "Build Amazing UserInterfaces",
                    Body = "With Xamarin.Forms you can build cool and amazing UIs using Custom Render",
                    CoverImage = ImageSource.FromFile("ui.jpg")
                }
            };
        }

        public List<Article> GetArticles()
        {
            return articles;
        }

        public void UpdateArticle(Article article)
        {
            if (article.ID == 0)
            {
                article.ID = articles.Count + 1;
                articles.Add(article);
            }
            else
            {
                Article oldArticle = articles.SingleOrDefault(a => a.ID == article.ID);
                oldArticle.Body = article.Body;
                oldArticle.Title = article.Title;
                oldArticle.CoverImage = article.CoverImage;
            }
        }
    }
}
