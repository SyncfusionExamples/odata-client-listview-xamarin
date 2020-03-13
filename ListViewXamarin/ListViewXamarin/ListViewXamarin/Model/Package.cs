using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    public class Package
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public bool IsLatestVersion { get; set; }
        public DateTime LastUpdated { get; set; }
        public int DownloadCount { get; set; }
        public int VersionDownloadCount { get; set; }
        public long PackageSize { get; set; }
        public string Authors { get; set; }
        public string Dependencies { get; set; }
    }
}
