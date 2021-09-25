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
            person = new Person("", "");
            PropertyChangedEventHandler Person_PropertyChanged = null;
            person.PropertyChanged += Person_PropertyChanged;

            person.FirstName = "Joe";
            person.LastName = "Smith";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = windowTitlePrefix + "- "+ this.person.FirstName + " "+ this. person.LastName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.person.FirstName = "Joe";
            this.Text = windowTitlePrefix + "- " + this.person.FirstName + " " + this.person.LastName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.person.FirstName = "Bob";
            this.Text = windowTitlePrefix + "- " + this.person.FirstName + " " + this.person.LastName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.person.LastName = "Smith";
            this.Text = windowTitlePrefix + "- " + this.person.FirstName + " " + this.person.LastName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.person.LastName = "Johnson";
            this.Text = windowTitlePrefix + "- " + this.person.FirstName + " " + this.person.LastName;
        }
    }
}
