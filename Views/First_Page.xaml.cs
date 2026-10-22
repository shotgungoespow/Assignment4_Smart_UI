using Assignment4_Smart_UI.Models;
using Assignment4_Smart_UI.Services;
using System.Security.Cryptography.X509Certificates;

namespace Assignment4_Smart_UI.Views;
public partial class First_Page : ContentPage
{
     List<Ingredient> items { get; set; }
    public First_Page()
	{
		InitializeComponent();
        BindingContext = this;
        items = DataRepository.GetIngredients().ToList();
        
	}
}