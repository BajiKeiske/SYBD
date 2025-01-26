using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store.Entities
{
    public class Musician
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Instrument { get; set; }
        public DateTime Date_of_birth { get; set; }

        public Musician() { }

        public Musician(int Id, string Name, string Surname, string Instrument, DateTime Date_of_birth)
        {
            this.Id = Id;
            this.Name = Name;
            this.Surname = Surname;
            this.Instrument = Instrument;
            this.Date_of_birth = Date_of_birth;
        }
    }

}
