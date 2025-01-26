using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store.Entities
{
    public class Composition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MusicianId { get; set; }
        public int EnsembleId { get; set; }
        public DateTime ReleaseYear { get; set; }

        public Composition() { }

        public Composition(int id, string name, int musicianId, int ensembleId, DateTime releaseYear)
        {
            this.Id = id;
            this.Name = name;
            this.MusicianId = musicianId;
            this.EnsembleId = ensembleId;
            this.ReleaseYear = releaseYear;
        }
        public override string ToString()
        {
            return $"{Id}: {Name} (Музыкант ID: {MusicianId}, Ансамбль ID: {EnsembleId}, Год выпуска: {ReleaseYear:yyyy})";
        }
    }

}
