using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_RemoteControl
{
    class LightOffCommand : ICommand
    {
        private Light light;

        public LightOffCommand(Light alight)
        {
            this.light = alight;
        }

        public void Execute()
        {
            light.off();
        }

        public void Unexecute()
        {
            light.on();
        }
    }
}
