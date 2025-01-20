using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store.Entities
{
    public class Musician
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string instrument { get; set; }
        public DateTime date_of_birth { get; set; }

        public Musician() { }

        public Musician(int id, string name, string surname, string instrument, DateTime date_of_birth)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.instrument = instrument;
            this.date_of_birth = date_of_birth;
        }
    }

}
