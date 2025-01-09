using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_store
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthday { get; set; } 
        public string email { get; set; }
        public string phone_number { get; set; }
        public Client() { }
        public Client(int id, string name, string surname, DateTime birthday, string email, string phone_number)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
            this.email = email;
            this.phone_number = phone_number;
        }

        public override string ToString()
        {
            return $"{id}: {name} {surname} {birthday.ToShortDateString()} ({email}, {phone_number})";
        }
    }
}
