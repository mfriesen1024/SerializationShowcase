using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Obj
{
    internal class ObjSpinner:MonoBehaviour
    {

        void Update()
        {
            // Spin the object.
            Vector3 rot = transform.eulerAngles;
            rot.z += 30*Time.deltaTime;
        }
    }
}
