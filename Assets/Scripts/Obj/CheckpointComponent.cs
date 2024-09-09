using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Obj
{
    /// <summary>
    /// Checkpoint stores player's last position.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    internal class CheckpointComponent:MonoBehaviour
    {
        public CheckpointInfo data;

        private void Start()
        {
            // Construct the checkpointinfo object.
            data = new CheckpointInfo();
            data.position = transform.position;
            data.sceneNum = SceneManager.GetActiveScene().buildIndex;
        }
    }

    /// <summary>
    /// Defines a checkpoint for the saving process.
    /// </summary>
    [Serializable]
    public struct CheckpointInfo
    {
        public static CheckpointInfo defaultCheckpoint { get { return new CheckpointInfo()
        {
            sceneNum = 0,
            position = Vector3.zero
        }; } }

        public int sceneNum;
        public Vector3 position;
    }
}
