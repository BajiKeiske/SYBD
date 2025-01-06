using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store
{
    public class Musician_Composition
    {
        public int id;
        public int musician_id;
        public int composition_id;

        public Musician_Composition(int id, int musician_id, int composition_id)
        {
            this.id = id;
            this.musician_id = musician_id;
            this.composition_id = composition_id;
        }
    }
}

