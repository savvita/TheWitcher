using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheWitcherManager.ViewModel;

namespace TheWitcherManager.View
{
    /// <summary>
    /// Interaction logic for AddNewCharacterView.xaml
    /// </summary>
    public partial class AddNewCharacterView : Window
    {
        public AddNewCharacterView()
        {
            InitializeComponent();
            AddNewCharacterViewModel model = new AddNewCharacterViewModel();
            model.Closing += () =>
            {
                DialogResult = true;
                this.Close();
            };
            this.DataContext = model;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
