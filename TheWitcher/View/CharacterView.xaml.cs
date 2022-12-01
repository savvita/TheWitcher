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

namespace TheWitcher.View
{
    /// <summary>
    /// Interaction logic for CharacterView.xaml
    /// </summary>
    public partial class CharacterView : Window
    {
        public CharacterView()
        {
            InitializeComponent();
        }

        public CharacterView(Character character) : this()
        {
            this.Title = character.Name;
            this.DataContext = character;
        }
    }
}
