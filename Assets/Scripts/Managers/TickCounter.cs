using System;

namespace Assets.Scripts.Managers
{
    public class TickCounter
    {
        /// <summary>
        /// How many updates should occur before execution.
        /// </summary>
        public int interval = 4;
        /// <summary>
        /// The action to execute when updating the tick.
        /// </summary>
        public Action action = () => { };

        int tickCount = 0;

        /// <summary>
        /// Increment counter, check if we need to execute action.
        /// </summary>
        public void Tick()
        {
            if (tickCount == 0) { action(); }
            tickCount++;
            if (tickCount == interval) { tickCount = 0; }
        }
    }
}
