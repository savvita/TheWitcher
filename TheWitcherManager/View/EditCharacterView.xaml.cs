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
using TheWitcherDBLibrary.Model;
using TheWitcherManager.ViewModel;

namespace TheWitcherManager.View
{
    /// <summary>
    /// Interaction logic for EditCharacterView.xaml
    /// </summary>
    public partial class EditCharacterView : Window
    {
        public EditCharacterView()
        {
            InitializeComponent();

        }

        public EditCharacterView(Character character) : this()
        {
            InitializeComponent();
            EditCharacterViewModel model = new EditCharacterViewModel(character);
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
