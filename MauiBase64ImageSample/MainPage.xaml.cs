namespace MauiBase64ImageSample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnDoThingsClicked(object sender, EventArgs e)
	{
		using var imageEncodeStream = await FileSystem.OpenAppPackageFileAsync("dotnet-maui-purple.png");
		using var memoryStream = new MemoryStream();

        imageEncodeStream.CopyTo(memoryStream);
        base64EncodedImage.Text = Convert.ToBase64String(memoryStream.ToArray());

		var imageBytes = Convert.FromBase64String(Base64ImageProvider.Base64EncodedImage);

        MemoryStream imageDecodeStream = new(imageBytes);
		base64DecodedImage.Source = ImageSource.FromStream(() => imageDecodeStream);
    }
}

