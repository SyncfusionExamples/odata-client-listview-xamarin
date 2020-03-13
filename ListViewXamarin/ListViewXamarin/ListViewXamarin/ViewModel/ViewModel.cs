using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class ViewModel : INotifyPropertyChanged
    {
        private IEnumerable<PackageViewModel> packages;
        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }
        public Command SearchCommand { get; set; }
        public Command TapCommand { get; set; }
        public IEnumerable<PackageViewModel> Packages
        {
            get { return packages; }
            set
            {
                packages = value;
                OnPropertyChanged("Packages");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            SearchCommand = new Command(OnSearch);
            TapCommand = new Command(OnTapped);
            Packages = new ObservableCollection<PackageViewModel>();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void OnSearch(object obj)
        {
            try
            {
                IsVisible = true;
                var packages = await GetPackages();
                if (packages != null)
                    SetSource(packages);
                IsVisible = false;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Error" + "Connect to the internet and try again..!");
                IsVisible = false;
            }
        }
        private void OnTapped(object obj)
        {
            var package = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as PackageViewModel;
            var detailsPage = new DetailsPage();
            detailsPage.BindingContext = package;
            (Application.Current.MainPage as NavigationPage).PushAsync(detailsPage);
        }
            
        private void SetSource(IEnumerable<Package> packages)
        {
            Packages = packages.Select(x => new PackageViewModel(x));
        }

        private async Task<IEnumerable<Package>> GetPackages()
        {
            var odataClient = new ODataClient("https://nuget.org/api/v1");
            var command = odataClient
                .For<Package>("Packages")
                .OrderByDescending(x => x.DownloadCount)
                .Top(20);

            command.OrderBy(x => x.Id);
            command.Filter(x => x.Title.Contains("Xamarin") && x.IsLatestVersion);
            command.Select(x => new { x.Id, x.Title, x.Version, x.LastUpdated, x.DownloadCount, x.VersionDownloadCount, x.PackageSize, x.Authors, x.Dependencies });

            return await command.FindEntriesAsync();
        }
    }
}
