using VirtualGamepad.Mapping;
using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualGamepad.ControllerModules
{
    public class AnalogStick : IControllerModule
    {
        public enum Direction
        {
            TOP = 0, RIGHT = 1, DOWN = 2, LEFT = 3
        };

        #region Configuration Attributes

        private IAnalogStickMapping mapping;

        private int minDirectionValue;
        private int maxDirectionValue;

        private int buttonIndex; //< Index des Clicks des Analogsticks 

        private Func<JoystickState, int> getXAxis; //< Hier wird die korrekte Variable des States angesprochen um die X-Achse auszulesen
        private Func<JoystickState, int> getYAxis; //y Hier wird die korrekte Variable des States angesprochen um die Y-Achse auszulesen

        #endregion // Configuration Attributes


        #region State Attributes

        private int xAxis;
        private int yAxis;

        private int[] movement;

        private bool clicked; //< Ist der Stick aktuell geklicked?

        #endregion // State Attributes


        public AnalogStick(int minDirectionValue, int maxDirectionValue, int buttonIndex, Func<JoystickState, int> getXAxis, Func<JoystickState, int> getYAxis)
        {
            this.minDirectionValue = minDirectionValue;
            this.maxDirectionValue = maxDirectionValue;

            this.buttonIndex = buttonIndex;

            this.getXAxis = getXAxis;
            this.getYAxis = getYAxis;

            movement = new int[4];

            clicked = false;
        }

       
        public void update(JoystickState stick)
        {
            this.xAxis = getXAxis(stick);
            this.yAxis = getYAxis(stick);

            if(xAxis < maxDirectionValue/2)
            {
                this.movement[(int)Direction.LEFT] = Math.Abs(maxDirectionValue / 2 - xAxis);
                this.movement[(int)Direction.RIGHT] = 0;
            }
            else
            {
                this.movement[(int)Direction.LEFT] = 0;
                this.movement[(int)Direction.RIGHT] = Math.Abs(maxDirectionValue / 2 - xAxis);
            }

            if (yAxis < maxDirectionValue / 2)
            {
                this.movement[(int)Direction.TOP] = Math.Abs(maxDirectionValue / 2 - yAxis);
                this.movement[(int)Direction.DOWN] = 0;
            }
            else
            {
                this.movement[(int)Direction.TOP] = 0;
                this.movement[(int)Direction.DOWN] = Math.Abs(maxDirectionValue / 2 - yAxis);
            }

            clicked = stick.GetButtons()[buttonIndex] != 0;
        }


        public void translateInput()
        {
            this.mapping.map(this);
        }


        #region Properties

        public int[] Movement
        {
            get { return movement; }
        }

        public bool Clicked
        {
            get { return clicked; }
            private set { clicked = value; }
        }

        public IAnalogStickMapping Mapping
        {
            get { return mapping; }
            set { mapping = value; }
        }
        #endregion // Properties

        
    }
}
