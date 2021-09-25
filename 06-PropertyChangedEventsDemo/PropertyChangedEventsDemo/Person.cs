using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChangedEventsDemo
{
    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if(value == this.firstName) { return; }
                this.firstName = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value == this.lastName) { return; }
                this.lastName = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

    }
}
