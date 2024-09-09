namespace Assets.Player
{
    /// <summary>
    /// This manages the player's stats.
    /// </summary>
    internal class StatManager
    {
        public int hp = 10, mp = 10, xp = 0, score = 0;
        public int lastCheckpoint = -1;
        /// <summary>
        /// Progression indicator.
        /// </summary>
        public bool[] bricks = new bool[3] {false,false,false };
    }
}
