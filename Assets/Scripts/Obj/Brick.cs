using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obj
{
    /// <summary>
    /// An object for progression things.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    internal class Brick:MonoBehaviour
    {
        /// <summary>
        /// Which brick number is this? Used to determine completion.
        /// </summary>
        public int brickID;
    }
}
