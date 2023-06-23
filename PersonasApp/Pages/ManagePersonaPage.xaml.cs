using Android.OS;
using PersonasApp.DataServices;
using PersonasApp.Models;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;

namespace PersonasApp.Pages;

[QueryProperty(nameof(Persona), "Persona")]
public partial class ManagePersonaPage : ContentPage
{
    private readonly IRestDataService _dataService;
	Persona _persona;
	bool _isNew;

	public Persona Persona
	{
		get => _persona;
		set
		{
			_isNew = IsNew(value);
			_persona = value;
			OnPropertyChanged();
		}
	}

    public ManagePersonaPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;
		BindingContext = this;
	}

	bool IsNew(Persona persona)
	{
		if (persona.Id == 0)
			return true;

		return false;
	}

	
	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		if (_isNew)
		{
            Debug.WriteLine("********** ADD NEW ITEM");
            await _dataService.AddPersonaAsync(Persona);
        }
		else
		{
            Debug.WriteLine("********** UPDATE ITEM");
            await _dataService.UpdatePersonasAsync(Persona);         

        }
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
		await _dataService.DeletePersonaAsync(Persona.Id);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
}