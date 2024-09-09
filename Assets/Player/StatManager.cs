namespace Assets.Player
{
    /// <summary>
    /// This manages the player's stats.
    /// </summary>
    internal class StatManager
    {
        public int hp, mp, xp, score;
        public int lastCheckpoint;
        /// <summary>
        /// Progression indicator.
        /// </summary>
        public bool[] bricks;
    }
}
