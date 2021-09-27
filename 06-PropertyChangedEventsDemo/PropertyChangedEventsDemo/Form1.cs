using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyChangedEventsDemo
{
    public partial class Form1 : Form
    {
        private Person person;
        private const string windowTitlePrefix = "Cpts 321: Property Changed Events Demo";

        public Form1()
        {
            InitializeComponent();
            person = new Person("","");
            person.PropertyChanged += Person_PropertyChanged;

            person.FirstName = "Joe";
            person.LastName = "Smith";
        }

        private void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if("FirstName" == e.PropertyName)
            {
                btnFirstName1.Text = "First name is currently " + person.FirstName + " Click to change to " +
                    btnFirstName1.Tag.ToString() + ".";
                btnFirstName2.Text = "First name is currently " + person.FirstName + " Click to change to " +
                    btnFirstName2.Tag.ToString() + ".";
            }

            if ("LastName" == e.PropertyName)
            {
                btnLastName1.Text = "Last name is currently " + person.LastName + " Click to change to " +
                    btnLastName1.Tag.ToString() + ".";
                btnLastName2.Text = "Last name is currently " + person.LastName + " Click to change to " +
                    btnLastName2.Tag.ToString() + ".";
            }

            this.Text = windowTitlePrefix + "- " + this.person.FirstName + " " + this.person.LastName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void btnFirstName_Click(object sender, EventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();

            if (this.person.FirstName != tag)
            {
                this.person.FirstName = tag;
            }

        }

        private void btnLastName_Click(object sender, EventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            if (this.person.LastName != tag)
            {
                this.person.LastName = tag;
            }
        }

    }
}
