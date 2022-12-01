using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWitcherDBLibrary.Model;
using TheWitcherDBLibrary.DBAccess;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace TheWitcherManager.ViewModel
{
    internal class WitcherManagerViewModel
    {
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();

        public Character? SelectedCharacter { get; set; }

        public WitcherManagerViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            Characters.Clear();

            foreach(var character in DBData.GetAllCharacters())
            {
                Characters.Add(character);
            }
        }

        private RelayCommand? deleteCmd;
        public RelayCommand DeleteCmd
        {
            get => deleteCmd ?? new RelayCommand(() =>
            {
                if (SelectedCharacter != null)
                {
                    DBData.RemoveCharacter(SelectedCharacter);
                    Refresh();
                }
            });
        }
    }
}
