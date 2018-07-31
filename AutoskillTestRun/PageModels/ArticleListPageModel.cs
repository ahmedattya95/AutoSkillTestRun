using AutoskillTestRun.Models;
using AutoskillTestRun.Pages;
using AutoskillTestRun.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AutoskillTestRun.PageModels
{
    public class ArticleListPageModel : BasePageModel
    {
        IDatabaseService databaseService;

        public ObservableCollection<Article> Articles { get; set; }

        public ReactiveCommand AddArticleCommand { get; private set; }

        public ReactiveCommand SelectArticleCommand { get; private set; }

        public ArticleListPageModel(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;

            // Get all the articles 
            Articles = new ObservableCollection<Article>(databaseService.GetArticles());

            AddArticleCommand = ReactiveCommand.Create(async () => await CoreMethods.PushPageModel<ArticlePageModel>(new Article { Title = "Hello", CoverImage = ImageSource.FromFile("addimage.png") }));

            SelectArticleCommand = ReactiveCommand.Create<SelectedItemChangedEventArgs>(SelectArticleAction);
        }

        Article selectedArticle;

        public Article SelectedArticle
        {
            get
            {
                return selectedArticle;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref selectedArticle, value);
            }
        }

        // returns the object back to whoever pushed the pageModel
        public override void ReverseInit(object returnedData)
        {
            var newArticle = returnedData as Article;

            if (!Articles.Contains(newArticle))
                Articles.Add(newArticle);
        }

        async void SelectArticleAction(SelectedItemChangedEventArgs args)
        {
            Article article = args.SelectedItem as Article;

            if (article == null)
                return;

            var page = CurrentPage as ArticleListPage;
            page.DeselectListView();
            article.Views++;  // Increase the Views 
            await CoreMethods.PushPageModel<ArticlePageModel>(article);
        }
    }
}
