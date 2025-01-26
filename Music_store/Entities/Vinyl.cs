using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store.Entities
{
    public class Vinyl
    {
        public int Id { get; set; }
        public string LabelNumber { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int MusicianId { get; set; }
        public int EnsembleId { get; set; }
        public string Genre { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public int SoldLastYear { get; set; }
        public int SoldThisYear { get; set; }
        public int Stock { get; set; }
        public byte[] Image { get; set; }
    }

}
