using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
