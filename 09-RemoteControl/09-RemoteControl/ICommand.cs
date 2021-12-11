using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_RemoteControl
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}
