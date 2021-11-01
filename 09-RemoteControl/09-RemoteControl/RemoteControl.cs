using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_RemoteControl
{
    // Invoker
    internal class RemoteControl
    {
        ICommand[] onCommands;
        ICommand[] offCommands;
        ICommand undoCommand;

        public RemoteControl(ushort numberOfSlots)
        {
            this.onCommands = new ICommand[numberOfSlots];
            this.offCommands = new ICommand[numberOfSlots];

            NoCommand noCommand = new NoCommand();
            for(int curSlot = 0; curSlot < numberOfSlots; curSlot++)
            {
                onCommands[curSlot] = noCommand;
                offCommands[curSlot] = noCommand;
            }
            undoCommand = noCommand;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            this.onCommands[slot] = onCommand;
            this.offCommands[slot] = offCommand;
        }

        internal void OffButtonPushed(int slot)
        {
            this.offCommands[slot].Execute();
            undoCommand = this.offCommands[slot];
        }

        internal void OnButtonPushed(int slot)
        {
            this.onCommands[slot].Execute();
            undoCommand = this.onCommands[slot];
        }

        internal void UndoButtonPushed()
        {
            undoCommand.Unexecute();
        }

        public void ShowInfo(TextWriter tw)
        {
            StringBuilder sb = new StringBuilder("\n ------- Remote Control ---------\n");
            for (int i = 0; i < this.onCommands.Length; i++)
            {
                sb.Append("[Slot" + i + "]"
                    + "     "
                    + onCommands[i].GetType()
                    + "     "
                    + offCommands[i].GetType()
                    + "\n");
            }
            sb.Append("[undo] "
                + undoCommand.GetType()
                + "\n");
            sb.AppendLine("-----------------------------");
            tw.WriteLine(sb);
        }
    }
}
