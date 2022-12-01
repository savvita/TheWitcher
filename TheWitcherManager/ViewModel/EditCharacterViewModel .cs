using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheWitcherDBLibrary.DBAccess;
using TheWitcherDBLibrary.Model;

namespace TheWitcherManager.ViewModel
{
    internal class EditCharacterViewModel : INotifyPropertyChanged
    {
        public string? Name { get; set; }
        public string? ImageURL { get; set; }

        public List<Chapter> Chapters { get; set; }

        public ObservableCollection<Chapter> SelectedChapters { get; set; } = new ObservableCollection<Chapter>();

        private Chapter? selectedChapter;
        public Chapter? SelectedChapter
        {
            get => selectedChapter;
            set
            {
                selectedChapter = value;
                OnPropertyChanged(nameof(SelectedChapter));
            }
        }


        public List<Occupation> Occupations { get; set; }
        public ObservableCollection<Occupation> SelectedOccupations { get; set; } = new ObservableCollection<Occupation>();

        public Occupation? SelectedOccupation { get; set; }

        public List<BelongsTo> BelongsTo { get; set; }
        public ObservableCollection<BelongsTo> SelectedBelongsTo { get; set; } = new ObservableCollection<BelongsTo>();

        public BelongsTo? SelectedBelongs { get; set; }

        public int SexId { get; set; }

        public List<Race> Races { get; set; }
        public Race? SelectedRace { get; set; }

        public string? Death { get; set; }

        public string? Description { get; set; }

        private Character character;

        public EditCharacterViewModel(Character character)
        {
            this.character = character;
            Chapters = DBData.GetAllChapters();
            Occupations = DBData.GetAllOccupations();
            Races = DBData.GetAllRaces();
            BelongsTo = DBData.GetAllBelongs();

            if (Chapters.Count > 0)
            {
                SelectedChapter = Chapters[0];
            }

            Death = character.Death;
            Name = character.Name;
            ImageURL = character.ImageUrl;
            SexId = (int)character.SexId;
            SelectedRace = character.Race;
            Description = character.Description;
            
            foreach(var chapter in DBData.GetChaptersByCharacterId(character.Id))
            {
                SelectedChapters.Add(chapter);
            }

            foreach (var occupation in DBData.GetOccupationsByCharacterId(character.Id))
            {
                if (occupation != null)
                {
                    SelectedOccupations.Add(occupation);
                }
            }

            foreach (var belong in DBData.GetBelongsByCharacterId(character.Id))
            {
                if (belong != null)
                {
                    SelectedBelongsTo.Add(belong);
                }
            }
        }

        public event Action? Closing;
        public event PropertyChangedEventHandler? PropertyChanged;

        private RelayCommand? editCmd;

        public RelayCommand EditCmd
        {
            get => editCmd ?? new RelayCommand(EditCharacter);
        }

        private RelayCommand? addChapterCmd;

        public RelayCommand AddChapterCmd
        {
            get => addChapterCmd ?? new RelayCommand(() =>
            {
                if(SelectedChapter != null && !SelectedChapters.Contains(SelectedChapter))
                {
                    SelectedChapters.Add(SelectedChapter);
                }
            });
        }

        private RelayCommand? addOccupationCmd;

        public RelayCommand AddOccupationCmd
        {
            get => addOccupationCmd ?? new RelayCommand(() =>
            {
                if (SelectedOccupation != null && !SelectedOccupations.Contains(SelectedOccupation))
                {
                    SelectedOccupations.Add(SelectedOccupation);
                }
            });
        }

        private RelayCommand? addBelongsCmd;

        public RelayCommand AddBelongsCmd
        {
            get => addBelongsCmd ?? new RelayCommand(() =>
            {
                if (SelectedBelongs != null && !SelectedBelongsTo.Contains(SelectedBelongs))
                {
                    SelectedBelongsTo.Add(SelectedBelongs);
                }
            });
        }

        private void EditCharacter()
        {
            Character ch = new Character()
            {
                Name = Name,
                Description = Description,
                ImageUrl = ImageURL,
                SexId = SexId,
                Death = Death
            };

            if(SelectedRace != null)
            {
                ch.RaceId = SelectedRace.Id;
            }

            ch.Id = character.Id;

            try
            {
                DBData.UpdateCharacter(ch, SelectedChapters, SelectedBelongsTo, SelectedOccupations);
            }
            catch { }

            Closing?.Invoke();
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Chapter? SelectedSelectedChapter { get; set; }
        private RelayCommand? removeChapterCmd;

        public RelayCommand RemoveChapterCmd
        {
            get => removeChapterCmd ?? new RelayCommand(() =>
            {
                if (SelectedSelectedChapter != null)
                {
                    SelectedChapters.Remove(SelectedSelectedChapter);
                }
            });
        }

        public Occupation? SelectedSelectedOccupation { get; set; }
        private RelayCommand? removeOccupationCmd;

        public RelayCommand RemoveOccupationCmd
        {
            get => removeOccupationCmd ?? new RelayCommand(() =>
            {
                if (SelectedSelectedOccupation != null)
                {
                    SelectedOccupations.Remove(SelectedSelectedOccupation);
                }
            });
        }

        public BelongsTo? SelectedSelectedBelongs { get; set; }
        private RelayCommand? removeBelongsCmd;

        public RelayCommand RemoveBelongsCmd
        {
            get => removeBelongsCmd ?? new RelayCommand(() =>
            {
                if (SelectedSelectedBelongs != null)
                {
                    SelectedBelongsTo.Remove(SelectedSelectedBelongs);
                }
            });
        }
    }
}
