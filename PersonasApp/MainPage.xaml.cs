using Android.OS;
using Java.Lang;
using PersonasApp.DataServices;
using PersonasApp.Models;
using PersonasApp.Pages;
using System.Diagnostics;
using System.Linq;
using Debug = System.Diagnostics.Debug;

namespace PersonasApp;

public partial class MainPage : ContentPage
{
	private readonly IRestDataService _dataService;
	public MainPage(IRestDataService dataService)
	{
		InitializeComponent();
		_dataService = dataService;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();

		collectionView1.ItemsSource = await _dataService.GetAllPersonasAsync();

	}

	async void OnAddPersonaClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("********* ADD BUTTON CLICKED");

		var navigationParameter = new Dictionary<string, object>
		{
			{ nameof(Persona), new Persona()}
		};

		await Shell.Current.GoToAsync(nameof(ManagePersonaPage), navigationParameter);

	}

	async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Debug.WriteLine("*********** CLICK EN EL CONTACTO");

        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(Persona), e.CurrentSelection.FirstOrDefault() as Persona}
        };

        await Shell.Current.GoToAsync(nameof(ManagePersonaPage), navigationParameter);

    }


	
}

