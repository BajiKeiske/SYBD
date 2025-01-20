using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store.Entities
{
    public class Composition
    {
        public int id { get; set; }
        public string name { get; set; }
        public int musicianId { get; set; }
        public int ensembleId { get; set; }
        public DateTime releaseYear { get; set; }

        public Composition() { }

        public Composition(int id, string name, int musicianId, int ensembleId, DateTime releaseYear)
        {
            id = id;
            name = name;
            musicianId = musicianId;
            ensembleId = ensembleId;
            releaseYear = releaseYear;
        }

        public override string ToString()
        {
            return $"{id}: {name} (Музыкант ID: {musicianId}, Ансамбль ID: {ensembleId}, Год выпуска: {releaseYear:yyyy})";
        }
    }

}
