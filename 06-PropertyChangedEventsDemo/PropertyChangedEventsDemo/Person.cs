using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChangedEventsDemo
{
    public class Person
    {
        private string firstName;
        private string lastName;

        public Person()
        {
            this.firstName = null;
            this.lastName = null;
        }

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetFirstName()
        {
            return this.lastName;
        }

    }
}
