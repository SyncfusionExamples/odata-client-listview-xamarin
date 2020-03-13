# How to bind OData to Xamarin.Forms ListView (SfListView) ?
You can bind the OData as the DataSource to SfListView using the OData Client library in Xamarin.Forms. The following article explains you about how to bind OData to ListView.

https://www.syncfusion.com/kb/11211/how-to-bind-odata-to-xamarin-forms-listview-sflistview

**NuGet to use ODataClient in your application**

You need to install the Simple.OData.Client to your application to feed the OData to SfListView.

**C#**

Fetches the OData using ODataClient using the OData library.
``` c#
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
```
**C#**

Bind the OData to SfListView.
```xml
<syncfusion:SfListView ItemsSource="{Binding Packages}"
                        AutoFitMode="DynamicHeight">
    <syncfusion:SfListView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <ViewCell.View>
                    <StackLayout Padding="5,5"
                                    Orientation="Vertical"
                                    VerticalOptions="FillAndExpand">
                        <Label Text="{Binding ShortSummary}"/>
                    </StackLayout>
                </ViewCell.View>
            </ViewCell>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```
**Output**

![OData](https://github.com/SyncfusionExamples/odata-client-listview-xamarin/blob/master/ScreenShots/OData.jpg)



