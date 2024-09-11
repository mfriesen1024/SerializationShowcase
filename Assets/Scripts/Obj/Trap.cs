using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obj
{
    /// <summary>
    /// Hurts the player when run over.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    internal class Trap:MonoBehaviour
    {
        public int damage = 16;
    }
}
