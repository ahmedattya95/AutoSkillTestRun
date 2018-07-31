using AutoskillTestRun.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoskillTestRun.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArticleListPage : BasePage
	{
		public ArticleListPage ()
		{
			InitializeComponent ();
		}

        public void DeselectListView()
        {
            ListView.SelectedItem = null;
        }
    }
}