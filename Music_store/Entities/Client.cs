using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store.Entities
{
    public class Client
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone_number { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public Client() { }
        public Client(int Id, string Name, string Surname, DateTime Birthday, string Email, string Phone_number)
        {
            this.Id = Id;
            this.Name = Name;
            this.Surname = Surname;
            this.Birthday = Birthday;
            this.Email = Email;
            this.Phone_number = Phone_number;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} {Surname} {Birthday.ToShortDateString()} ({Email}, {Phone_number})";
        }
    }
}
