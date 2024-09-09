namespace Assets.Scripts.Player
{
    /// <summary>
    /// This manages the player's stats.
    /// </summary>
    public class StatManager
    {
        /// <summary>
        /// Progression indicator.
        /// </summary>
        public bool[] bricks = new bool[3] { false, false, false };
        private int _hp = 10;
        private int _mp = 10;
        private int _xp = 0;
        private int score = 0;
        private int level = 0;
        public int lastCheckpoint = -1;

        public int hp { get => _hp; set => _hp=value; }
        public int mp { get => _mp; set => _mp=value; }
        public int xp { get => _xp; set => SetXP(value); }
        public int Score { get => score; set => score=value; }
        public int Level { get => level; }

        // Set the xp and define a level system.
        void SetXP(int value)
        {
            _xp = value;

            int localXP = value;
            int nextLevel = 1;
            int xpToNext = CalcReqXP(nextLevel);
            
            int CalcReqXP(int levelNum) {
                return 10*levelNum;
            }

            while(localXP > xpToNext)
            {
                nextLevel++;
                xpToNext = CalcReqXP(nextLevel);
            }

            // save the level
            level = nextLevel;
        }
    }
}
