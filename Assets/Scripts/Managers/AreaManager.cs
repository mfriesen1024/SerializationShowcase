using Assets.Scripts.Obj;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// This handles area transitions.
    /// </summary>
    internal class AreaManager
    {
        /// <summary>
        /// Its probably good practice to consolidate loading/saving into one spot and let the manager sort scenes and whatnot.
        /// </summary>
        public void LoadScene(int id)
        {
            SceneManager.LoadScene(id);

            // I never want to return to scene 0, so just send to state 1 because I'm lazy.
            // We could sort scenes and other garbage, but thats out of scope.
            GameManager.Instance.uiManager.UIState = 1;

             GameManager.Instance.PlayerController.transform.position = Vector3.zero; 
        }

        /// <summary>
        /// Loads to a checkpoint.
        /// </summary>
        /// <param name="checkpoint">The checkpoint to load.</param>
        public void LoadFromCheckpoint(CheckpointInfo checkpoint)
        {
            LoadScene(checkpoint.sceneNum);
            GameManager.Instance.PlayerController.transform.position = checkpoint.position;
        }
    }
}
