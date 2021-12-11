using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_RemoteControl
{
    class RemoteLoader
    {
        static void Main(string [] args)
        {
            RemoteControl remoteControl = new RemoteControl(2);

            Light livingRoomLight = new Light("living room");
            Light kitchenLight = new Light("Kitchen");

            LightOnCommand livingRoomLigthOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLigthOff = new LightOffCommand(livingRoomLight);
            LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);

            /************* Command Preperation *******************************/
            remoteControl.SetCommand(0, livingRoomLigthOn, livingRoomLigthOff);
            remoteControl.SetCommand(1, kitchenLightOn, kitchenLightOff);
            /*****************************************************************/


            remoteControl.ShowInfo(Console.Out);

            remoteControl.OnButtonPushed(0); //on living room light

            remoteControl.UndoButtonPushed();//undo living room light

            remoteControl.OnButtonPushed(1); // on kitchen light

            remoteControl.ShowInfo(Console.Out);

            remoteControl.UndoButtonPushed();//undo kitchen light


            Console.ReadKey();




        }

    }
}
