using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoskillTestRun.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Article
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public ImageSource CoverImage { get; set; }

        public int Views { get; set; }
    }
}
