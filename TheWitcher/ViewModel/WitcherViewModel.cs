using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWitcherDBLibrary.DBAccess;
using TheWitcherDBLibrary.Model;

namespace TheWitcher.ViewModel
{
    public class WitcherViewModel
    {
        private Chapter? selectedChapter;
        public Chapter? SelectedChapter
        {
            get => selectedChapter;
            set
            {
                selectedChapter = value;
                RefreshCharacters();
            }
        }

        private void RefreshCharacters()
        {
            Characters.Clear();
            SelectedCharacter = null;

            if(SelectedChapter == null)
            {
                return;
            }

            foreach(var character in DBData.GetCharactersByChapterId(SelectedChapter.Id))
            {
                Characters.Add(character);
            }
        }

        public Character? SelectedCharacter { get; set; }

        public List<Chapter> Chapters { get; set; }
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();

        public WitcherViewModel()
        {
            Chapters = DBData.GetAllChapters();
        }
        
    }
}
