using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PickerTuto
{
	public partial class MainPage : ContentPage
	{
        int _heightRequest =50;
        ObservableCollection<Colors> MyList = new ObservableCollection<Colors>();
        ObservableCollection<Colors> MyListChosen = new ObservableCollection<Colors>();

        public MainPage()
		{
			InitializeComponent();
            BindingContext = this;
            TheValueOne.ItemsSource = MyList;
            TheValueOne.HeightRequest = _heightRequest;

            TheValueTwo.ItemsSource = MyList;
            TheValueTwo.HeightRequest = _heightRequest;

            TheValueThree.ItemsSource = MyList;
            TheValueThree.HeightRequest = _heightRequest;

            TheValueFour.ItemsSource = MyList;
            TheValueFour.HeightRequest = _heightRequest;
        }
        public void AddBtn( object sender,EventArgs args)
        {
            var selectedValue = pikerDays.Items[pikerDays.SelectedIndex].ToString();
            var colorChosen = new Colors
            {
                NameEn = selectedValue
            };
            
            MyList.Add(colorChosen);
            _heightRequest = _heightRequest + 50;
            TheValueOne.ItemsSource = MyList;
            TheValueOne.HeightRequest = _heightRequest;

            TheValueTwo.ItemsSource = MyList;
            TheValueTwo.HeightRequest = _heightRequest;

            TheValueThree.ItemsSource = MyList;
            TheValueThree.HeightRequest = _heightRequest;

            TheValueFour.ItemsSource = MyList;
            TheValueFour.HeightRequest = _heightRequest;
        }
        public void ToDelete(object sender,EventArgs args)
        {
            var item = (Xamarin.Forms.Button)sender;
            Colors listitem = (from itm in MyList
                             where itm.NameEn == item.CommandParameter.ToString()
                             select itm)
                            .FirstOrDefault<Colors>();
            MyList.Remove(listitem);
        }
    }
}
