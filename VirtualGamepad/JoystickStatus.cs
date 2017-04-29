//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using FormsKeys = System.Windows.Forms.Keys;



//namespace JoystickInterface
//{
//    using Direction = JoystickInterface.ControllerModules.AnalogStick.Direction;
    
    
//    public class JoystickStatus
//    {    
//        static Dictionary<int, int> buttonsToKeys;
       


//        Joystick stick;

//        private bool[] oldButtons;
        
        

//        public JoystickStatus(Joystick s)
//        {
//            stick = s;
//            setStatus();

           
//        }

//        static JoystickStatus()
//        {
            

           
//        }

//        public void testSetKeyForA(int scancode)
//        {
//            buttonsToKeys[0] = scancode;
//        }

        


       


//        void setStatus()
//        {
//            //oldDirectionStatus = getDirectionStatus();
//            oldButtons = stick.buttons;
//        }

       


//        bool[] getPressedButtons()
//        {
//            var pressedButtons = new bool[11];
//            var downButtons = stick.buttons;

//            for (int i = 0; i < 11; ++i )
//            {
//                if(downButtons[i] == true && oldButtons[i] == false)
//                {
//                    pressedButtons[i] = true;
//                }
//                else
//                {
//                    pressedButtons[i] = false;
//                }
//            }

//            return pressedButtons;
//        }

//        bool[] getReleasedButtons()
//        {
//            var releasedButtons = new bool[11];
//            var downButtons = stick.buttons;

//            for (int i = 0; i < 11; ++i )
//            {
//                if(downButtons[i] == false && oldButtons[i] == true)
//                {
//                    releasedButtons[i] = true;
//                }
//                else
//                {
//                    releasedButtons[i] = false;
//                }
//            }

//            return releasedButtons;
//        }

       
//        public String step()
//        {
//            String s = "Direction:\tT\tR\tD\tL\n";
            
//            s +=       "Current:\t";
//            foreach(bool b in getDirectionStatus())
//            {
//                s += b + "\t";
//            }
//            s += "\n";

//            s += "Old:\t";
//            foreach(bool b in oldDirectionStatus)
//            {
//                s += b + "\t";
//            }
//            s += "\n";


           
//            s += "\n";

//            s += "Right:\t";
//            foreach(int i in stick.LeftStick.Movement)
//            {
//                s += i + "\t";
//            }
//            s += "\n";


//            var pressedButtons = getPressedButtons();
//            var relasedButtons = getReleasedButtons();

//            for (int i = 0; i < 11; ++i)
//            {
//                if (relasedButtons[i] == true)
//                {
//                    InputInterface.ReleaseKey((short)buttonsToKeys[i]);
//                }

//                if (pressedButtons[i] == true)
//                {
//                    InputInterface.PressKey((short)buttonsToKeys[i]);
//                }
//            }

//                setStatus();
//            return s;
               
//        }

//    }
//}
