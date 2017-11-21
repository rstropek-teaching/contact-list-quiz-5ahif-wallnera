using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListSwagger
{
    public class Person
    {

        public Person(int id, string firstname, string lastname, string email)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
        }

        public Person()
        {
            this.Id = 0;
            this.Firstname = "unknown";
            this.Lastname = "unknown";
            this.Email = "unknown";
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }


        public string FormatPersonToString()
        {
            string personserial = "";

            personserial += this.Id;
            personserial += this.Firstname;
            personserial += this.Lastname;
            personserial += this.Email;

            return personserial;
        }
    }
}
