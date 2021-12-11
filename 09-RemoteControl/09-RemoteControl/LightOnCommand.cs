using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_RemoteControl
{
    class LightOnCommand : ICommand
    {
        private Light light;

        public LightOnCommand(Light alight)
        {
            this.light = alight;
        }

        public void Execute()
        {
            light.on();
        }

        public void Unexecute()
        {
            light.off();
        }
    }
}
