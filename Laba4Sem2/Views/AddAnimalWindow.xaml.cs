using System.Globalization;
using System.Windows;
using Laba4Sem2.Model;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for AddAnimalWindow.xaml
    /// </summary>
    public partial class AddAnimalWindow : Window
    {
        private static List<string> _countryNames;
        private readonly Room room;
        static AddAnimalWindow()
        {
            InitializeCountryNames();
        }

        public AddAnimalWindow(Room room)
        {
            InitializeComponent();
            DataContext = this;
            GenerateCountryBox();
            this.room = room;
        }

        private static void InitializeCountryNames()
        {
            if (_countryNames == null)
            {
                RegionInfo country = new RegionInfo(new CultureInfo("en-US", false).LCID);
                _countryNames = new List<string>();

                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    try
                    {
                        country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                        _countryNames.Add(country.DisplayName.ToString());
                    }
                    catch
                    {
                        continue;
                    }
                }

                _countryNames = _countryNames.OrderBy(name => name).Distinct().ToList();
            }
        }

        private void GenerateCountryBox()
        {
            foreach (string item in _countryNames)
            {
                CountryBox.Items.Add(item);
            }
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            Animal animal = new Animal(animalName.Text, CountryBox.SelectedValue.ToString()!, ownName.Text, bornDate.SelectedDate!.Value);
            room.AddAnimal(new AccUnit(animal, DateTime.Now, 100));
            this.Close();
        }
    }
}
