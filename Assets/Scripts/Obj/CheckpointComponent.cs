using Assets.Scripts.Player;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Obj
{
    /// <summary>
    /// Checkpoint stores player's last position.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    internal class CheckpointComponent : MonoBehaviour
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
        public int sceneNum;
        public sv3 position;
    }
}
