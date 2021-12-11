using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_RemoteControl
{
    class Light
    {
        private string location;
        private LightStatus status;
        private enum LightStatus { LightOn, LightOff}

        public Light(string location)
        {
            this.location = location;
        }
        
        internal void off()
        {
            this.status = LightStatus.LightOff;
            Console.WriteLine("The light in the " + this.location + "is OFF");
        }
        
        internal void on()
        {
            this.status = LightStatus.LightOn;
            Console.WriteLine("The light in the " + this.location + "is ON");
        }

    }
}
