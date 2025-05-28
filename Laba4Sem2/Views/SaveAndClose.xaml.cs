using System.Windows;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for SaveAndClose.xaml
    /// </summary>
    public partial class SaveAndClose : Window
    {
        public SaveAndClose()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            App.Save();
            DialogResult = true;
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
