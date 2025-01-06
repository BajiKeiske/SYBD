using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store
{
    public class Musician
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Instrument { get; set; }

            public Musician(int id, string name, string surname, string instrument)
            {
                Id = id;
                Name = name;
                Surname = surname;
                Instrument = instrument;
            }

            // Конструктор без параметров для удобства работы
            public Musician() { }




        //public string name;
        //public string surname;
        //public int id;
        //public string instrument;

        //public Musician(string surname, string name, int id, string instrument)
        //{
        //    this.name = name;
        //    this.surname = surname;
        //    this.id = id;
        //    this.instrument = instrument;
        //}
    }
}
