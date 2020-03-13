using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultsPage : ContentPage
	{
		public ResultsPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, true);
        }
	}
}