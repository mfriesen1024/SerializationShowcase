using Assets.Scripts.Obj;
using UnityEngine;
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

            // Only set uistate if returning to menu.
            GameManager.Instance.uiManager.UIState = id == 0 ? 0 : 1;

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
