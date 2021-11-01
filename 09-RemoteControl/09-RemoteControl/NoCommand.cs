using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_RemoteControl
{
    class NoCommand : ICommand
    {
        public void Execute()
        {
        }

        public void Unexecute()
        {
        }
    }
}
