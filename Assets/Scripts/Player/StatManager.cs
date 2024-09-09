using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// This manages the player's stats.
    /// </summary>
    public class StatManager
    {
        /// <summary>
        /// For range checking hp and mp.
        /// </summary>
        int maxHPMP { get { return 10 + 2 * level; } }

        private int _hp = 10;
        private int _mp = 10;
        private int _xp = 0;
        private int score = 0;
        private int level = 0;
        public int lastCheckpoint = -1;
        public int hp { get => _hp; set => SetHP(value); }
        public int mp { get => _mp; set => SetMP(value); }
        public int xp { get => _xp; set => SetXP(value); }
        public int Score { get => score; set => score=value; }
        public int Level { get => level; }

        /// <summary>
        /// Progression indicator.
        /// </summary>
        public bool[] bricks = new bool[3] { false, false, false };

        /// <summary>
        /// Called every 4 game ticks, resulting in healing 5 hp and 5 mp per second.
        /// </summary>
        public void StatsTick()
        {
            hp++;
            mp++;
        }


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

        // used to rangecheck
        void SetHP(int value)
        {
            if(value > maxHPMP) { _hp = maxHPMP; }
            else if(value <= 0) { _hp = 0; Debug.LogWarning("HP is 0, player should die here."); }
            else { _hp = value; }
        }

        // used to rangecheck
        void SetMP(int value)
        {
            if (value > maxHPMP) { _mp = maxHPMP; }
            else if (value < 0) { _mp = 0; Debug.Log("MP shouldnt be less than 0."); }
            else { _mp = value; }
        }
    }
}
