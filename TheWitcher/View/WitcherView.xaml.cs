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
using TheWitcher.ViewModel;

namespace TheWitcher.View
{
    /// <summary>
    /// Interaction logic for WitcherView.xaml
    /// </summary>
    public partial class WitcherView : Window
    {
        public WitcherView()
        {
            InitializeComponent();
            this.DataContext = new WitcherViewModel();
        }
    }
}
