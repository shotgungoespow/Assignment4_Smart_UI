using Assignment4_Smart_UI.Models;
using Assignment4_Smart_UI.Services;

namespace Assignment4_Smart_UI.Views;
public partial class First_Page : ContentPage
{
    public List<Ingredient> Items { get; set; }
    public string Total_Weight;
    public First_Page()
	{
		InitializeComponent();

        Items = DataRepository.GetIngredients().ToList();
        Total_Weight = Weight_Calc();
        BindingContext = this;
        

    }
    public string Weight_Calc()
    {
        string result = "";
        string addition = "";
        double calc = 0;
        foreach (var item in Items)
        {
            if (item.Liquid)
            {
                addition = "ml";
            }
            else
            {
                addition = "gram";
            }
            calc = item.Weight * item.Amount;
            result = calc.ToString() + addition; 
            return result;
        }
        return result;
    }
}