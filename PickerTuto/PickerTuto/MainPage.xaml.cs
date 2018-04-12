using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private Dictionary<Colors, bool> _myDictionary;
        public Dictionary<Colors, bool> MyDictionary {
           get { return _myDictionary ; }
           set { _myDictionary = value;
                OnPropertyChanged("MyDictionary");
            }
        }


        ObservableCollection<ObservableDictionary> MyObservableDictionary = new ObservableCollection<ObservableDictionary>();


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


            MyDictionary = new Dictionary<Colors, bool>();
            MyDictionary.Add(new Colors() { NameEn = "blue" }, false);
            MyDictionary.Add(new Colors() { NameEn = "red" }, false);
            MyDictionary.Add(new Colors() { NameEn = "green" }, false);
            MyDictionary.Add(new Colors() { NameEn = "yellow" }, false);


            MyObservableDictionary = new ObservableCollection<ObservableDictionary>();
            MyObservableDictionary.Add(new ObservableDictionary() {Key= new Colors() { NameEn = "blue" },Value =false });
            MyObservableDictionary.Add(new ObservableDictionary() {Key= new Colors() { NameEn = "red" },Value =false });
            MyObservableDictionary.Add(new ObservableDictionary() {Key= new Colors() { NameEn = "greeyellow" },Value =false });
            MyObservableDictionary.Add(new ObservableDictionary() {Key= new Colors() { NameEn = "blue" },Value =false });
          


            TheValueFour.ItemsSource = MyDictionary;
            dictionary.ItemsSource = MyObservableDictionary;
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

        public void ToCheck(object sender, EventArgs args)
        {
            var item = (Button)sender;
            //_myDictionary.Add(new Colors() { NameEn = "silver" }, true);
           

            foreach (Colors kvp in _myDictionary.Keys.ToList())
            {
               

                if (_myDictionary[kvp] == false && kvp.NameEn== item.CommandParameter.ToString())
                {
                    TheValueFour.BeginRefresh();
                    //_myDictionary.Remove(kvp);
                    //_myDictionary.Add(kvp, true);
                    _myDictionary[kvp] = true;
                    TheValueFour.EndRefresh();
                    DisplayAlert("test Ckek", _myDictionary[kvp].ToString(), "ok");
                }
                else if (_myDictionary[kvp] == true && kvp.NameEn == item.CommandParameter.ToString())
                {
                    TheValueFour.BeginRefresh();
                    //_myDictionary.Remove(kvp);
                    //_myDictionary.Add(kvp, false);
                    _myDictionary[kvp] = false;
                    TheValueFour.EndRefresh();
                    DisplayAlert("test Ckek", _myDictionary[kvp].ToString(), "ok");
                }
            }
            

        }

        public void ToCheckColor(object sender, EventArgs args)
        {
            var item = (Button)sender;

            ObservableDictionary listitem = (from itm in MyObservableDictionary
                                             where itm.Key.NameEn == item.CommandParameter.ToString()
                                             select itm)
                            .FirstOrDefault<ObservableDictionary>();

            if (listitem.Value == false)
            {
                var oldidex = MyObservableDictionary.IndexOf(listitem);
                var itm = new ObservableDictionary() { Key = listitem.Key, Value = true };
                MyObservableDictionary[oldidex] = itm;

            }
            else {
                var oldidex = MyObservableDictionary.IndexOf(listitem);
                var itm = new ObservableDictionary() { Key = listitem.Key, Value = false };
                MyObservableDictionary[oldidex] = itm;
            }



  





        }
    }
}
