using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obj
{
    /// <summary>
    /// Gives player xp and score.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    internal class Coin:MonoBehaviour
    {
        ObjSpinner spinner;

        private void Start()
        {
            spinner = (ObjSpinner)gameObject.AddComponent(typeof(ObjSpinner));
        }
    }
}
