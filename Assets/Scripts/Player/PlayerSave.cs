using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    [Serializable]
    internal class PlayerSave
    {
        public int hp = 10, mp = 10, xp = 0, score = 0;
        public int lastCheckpoint = -1;
        /// <summary>
        /// Progression indicator.
        /// </summary>
        public bool[] bricks = new bool[3] { false, false, false };

        public static implicit operator PlayerSave(StatManager statMan)
        {
            PlayerSave save = new();

            save.hp = statMan.hp;
            save.mp = statMan.mp;
            save.xp = statMan.xp;
            save.score = statMan.Score;

            // progression stuff
            save.lastCheckpoint = statMan.lastCheckpoint;
            save.bricks = statMan.bricks;

            // return stuff
            return save;
        }

        // I think this needs to be implicit so I can cast to save, and it will implicitly cast to statman.
        public static implicit operator StatManager(PlayerSave save)
        {
            StatManager statMan = new();

            // XP must be set first due to the xp setter raising maxhp/mp.
            save.xp = statMan.xp;
            save.hp = statMan.hp;
            save.mp = statMan.mp;
            save.score = statMan.Score;

            // progression stuff
            save.lastCheckpoint = statMan.lastCheckpoint;
            save.bricks = statMan.bricks;

            return statMan;
        }
    }
}
