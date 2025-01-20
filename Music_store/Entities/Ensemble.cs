using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store.Entities
{
    public class Ensemble
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date_founded { get; set; }

        public Ensemble() { }

        public Ensemble(int id, string name, string description, DateTime date_founded)
        {
            Id = id;
            Name = name;
            Date_founded = date_founded;
        }
    }
}
