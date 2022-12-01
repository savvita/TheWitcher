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
    /// Interaction logic for WitcherManagerView.xaml
    /// </summary>
    public partial class WitcherManagerView : Window
    {
        WitcherManagerViewModel model = new WitcherManagerViewModel();
        public WitcherManagerView()
        {
            InitializeComponent();
            this.DataContext = model;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewCharacterView view = new AddNewCharacterView();
            view.ShowDialog();
            model.Refresh();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (model.SelectedCharacter != null)
            {
                EditCharacterView view = new EditCharacterView(model.SelectedCharacter);
                view.ShowDialog();
                model.Refresh();
            }
        }
    }
}
