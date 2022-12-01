using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWitcherDBLibrary.Model;

namespace TheWitcherDBLibrary.DBAccess
{
    public static class DBData
    {
        private static WitcherDbContext db = new WitcherDbContext();

        static DBData()
        {
            db.Sexes.Load();
            db.Races.Load();
            db.Occupations.Load();
        }

        public static List<Chapter> GetAllChapters()
        {
            return db.Chapters.ToList();
        }

        public static List<Character> GetAllCharacters()
        {
            return db.Characters.ToList();
        }

        public static List<Occupation> GetAllOccupations()
        {
            return db.Occupations.ToList();
        }

        public static List<Race> GetAllRaces()
        {
            return db.Races.ToList();
        }

        public static List<BelongsTo> GetAllBelongs()
        {
            return db.BelongsTos.ToList();
        }

        public static List<Character> GetCharactersByChapterId(int chapterId)
        {
            //It's terrible sql!
            return db.CharacterChapters.Where(ch => ch.ChapterId == chapterId)
                .Include(ch => ch.Character)
                .ThenInclude(ch => ch.CharacterBelongsTos)
                .ThenInclude(ch => ch.BelongTo)
                .Include(ch => ch.Character.CharacterOccupations)
                .ThenInclude(ch => ch.Occupation)
                .Select(ch => ch.Character)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public static void AddChapter(Chapter chapter)
        {
            db.Chapters.AddAsync(chapter);
            db.SaveChangesAsync();
        }

        public static void UpdateChapter(Chapter chapter)
        {
            db.Chapters.Update(chapter);
            db.SaveChangesAsync();
        }

        public static void RemoveCharacter(Character character)
        {
            var chapters = db.CharacterChapters.Where(c => c.CharacterId == character.Id).ToList();
            db.CharacterChapters.RemoveRange(chapters);

            var occupations = db.CharacterOccupations.Where(c => c.CharacterId == character.Id).ToList();
            db.CharacterOccupations.RemoveRange(occupations);

            var belongs = db.CharacterBelongsTos.Where(c => c.CharacterId == character.Id).ToList();
            db.CharacterBelongsTos.RemoveRange(belongs);

            var ch = db.Characters.Where(c => c.Id == character.Id).First();
            db.Characters.Remove(ch);
            db.SaveChanges();
        }

        public static void UpdateCharacter(Character character, IEnumerable<Chapter> chapters, IEnumerable<BelongsTo> belongsTo, IEnumerable<Occupation> occupations)
        {
            var ch = db.Characters.Where(c => c.Id == character.Id).First();
            ch.Description = character.Description;
            ch.Name = character.Name;
            ch.SexId = character.SexId;
            ch.ImageUrl = character.ImageUrl;
            ch.Death = character.Death;
            ch.RaceId = character.RaceId;

            //db.Characters.Update(ch);
            db.SaveChanges();

            UpdateCharacterChapters(character, chapters);
            UpdateCharacterOccupations(character, occupations);
            UpdateCharacterBelongs(character, belongsTo);
        }

        private static void UpdateCharacterChapters(Character character, IEnumerable<Chapter> chapters)
        {
            var characterChapters = db.CharacterChapters.Where(ch => ch.CharacterId == character.Id).ToList();

            db.CharacterChapters.RemoveRange(characterChapters);
            SaveChapters(character, chapters);
        }

        private static void UpdateCharacterOccupations(Character character, IEnumerable<Occupation> occupations)
        {
            var characterOccupations = db.CharacterOccupations.Where(ch => ch.CharacterId == character.Id).ToList();

            db.CharacterOccupations.RemoveRange(characterOccupations);
            SaveOccupations(character, occupations);
        }

        private static void UpdateCharacterBelongs(Character character, IEnumerable<BelongsTo> belongsTo)
        {
            var characterBelongs = db.CharacterBelongsTos.Where(ch => ch.CharacterId == character.Id).ToList();

            db.CharacterBelongsTos.RemoveRange(characterBelongs);
            SaveBelongs(character, belongsTo);
        }

        public static void AddCharacter(Character character, IEnumerable<Chapter> chapters, IEnumerable<BelongsTo> belongsTo, IEnumerable<Occupation> occupations)
        {
            db.Characters.AddAsync(character);
            db.SaveChanges();

            SaveChapters(character, chapters);
            SaveBelongs(character, belongsTo);
            SaveOccupations(character, occupations);
        }

        private static void SaveBelongs(Character character, IEnumerable<BelongsTo> belongsTo)
        {
            foreach (var belongs in belongsTo)
            {
                db.CharacterBelongsTos.Add(new CharacterBelongsTo()
                {
                    BelongToId = belongs.Id,
                    CharacterId = character.Id
                });
            }

            db.SaveChanges();
        }

        private static void SaveOccupations(Character character, IEnumerable<Occupation> occupations)
        {
            foreach (var occupation in occupations)
            {
                db.CharacterOccupations.Add(new CharacterOccupation()
                {
                    OccupationId = occupation.Id,
                    CharacterId = character.Id
                });
            }

            db.SaveChanges();
        }

        public static List<Occupation?> GetOccupationsByCharacterId(int id)
        {
            return db.CharacterOccupations.Where(o => o.CharacterId == id).Select(o => o.Occupation).ToList();
        }

        public static List<BelongsTo?> GetBelongsByCharacterId(int id)
        {
            return db.CharacterBelongsTos.Where(o => o.CharacterId == id).Select(o => o.BelongTo).ToList();
        }

        public static List<Chapter> GetChaptersByCharacterId(int id)
        {
            return db.CharacterChapters.Where(o => o.CharacterId == id).Select(o => o.Chapter).ToList();
        }

        private static void SaveChapters(Character character, IEnumerable<Chapter> chapters)
        {
            foreach (var chapter in chapters)
            {
                db.CharacterChapters.Add(new CharacterChapter()
                {
                    ChapterId = chapter.Id,
                    CharacterId = character.Id
                });
            }

            db.SaveChanges();
        }
    }
}
