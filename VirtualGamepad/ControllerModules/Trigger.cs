using VirtualGamepad.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualGamepad.ControllerModules
{
    public class Trigger : IControllerModule
    {

        public enum Side
        {
            RIGHT = 0,
            LEFT = 1
        };

        #region Configuration Attributes

        private int minimalValue;
        private int maximalValue;

        private TriggerToTemporaryCustomMapping mapping;

        #endregion // Configuration Attributes

        #region State Attributes

        private int[] movement;

        #endregion // State Attributes

        public Trigger(int minimalValue, int maximalValue)
        {
            this.minimalValue = minimalValue;
            this.maximalValue = maximalValue;

            movement = new int[2];
            movement[(int)Side.LEFT] = movement[(int)Side.RIGHT] = 0;
        }


        public void update(Microsoft.DirectX.DirectInput.JoystickState stick)
        {
            int absoluteMovement = stick.Z;
            int range = maximalValue - minimalValue;

            if(absoluteMovement < range/2)
            {
                movement[(int)Side.LEFT] = range / 2 - absoluteMovement;
                movement[(int)Side.RIGHT] = 0;
            }
            else 
            {
                movement[(int)Side.LEFT] = 0;
                movement[(int)Side.RIGHT] = absoluteMovement - range / 2;
            }
        }

        public void translateInput()
        {
            mapping.map(this);
        }

        public TriggerToTemporaryCustomMapping Mapping
        {
            get { return mapping; }
            set { mapping = value; }
        }

        public int[] Movement
        {
            get { return movement; }
            private set { movement = value; }
        }
    }
}
