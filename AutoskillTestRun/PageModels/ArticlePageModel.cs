using AutoskillTestRun.Models;
using AutoskillTestRun.Services;
using Plugin.Media;
//using Plugin.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutoskillTestRun.PageModels
{

    public class ArticlePageModel : BasePageModel
    {

        IDatabaseService databaseService;

        public Article Article { get; set; }

        public ReactiveCommand SaveCommand { get; private set; }

        public ReactiveCommand ChooseImageCommand { get; private set; }
        public ArticlePageModel(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;

            SaveCommand = ReactiveCommand.CreateFromTask(SaveArticle);

            ChooseImageCommand = ReactiveCommand.CreateFromTask(ChooseImage);
        }

        // Pick up an image from the studio of the camera 
        async Task ChooseImage()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await CoreMethods.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            await CoreMethods.DisplayAlert("File Location", file.Path, "OK");

            Article.CoverImage = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

        }

        public override void Init(object initData)
        {
            Article = initData as Article;

            if (Article == null)
                Article = new Article()
                {
                    CoverImage = ImageSource.FromFile("addimage.jpg")
                };
        }

        async Task SaveArticle()
        {
            databaseService.UpdateArticle(Article);

            await CoreMethods.PopPageModel(Article);
        }

    }

}
