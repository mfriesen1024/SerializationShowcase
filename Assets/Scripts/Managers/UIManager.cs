using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Managers
{
    internal class UIManager:MonoBehaviour
    {
        [SerializeField]Canvas menu, hud;
        [SerializeField] Button ng, lg, sc1, sc2, sc3;
        AreaManager am;
        public int UIState { get => uiState; set { SetUIState(value); } }
        int uiState;

        private void Start()
        {
            am = GameManager.Instance.areaManager;

            UIState = 0;

            // if new game, load level 1 with no questions asked.
            ng.clicked += () => { am.LoadScene(1); };
            lg.clicked += () => { throw new NotImplementedException("aaa!"); };
            sc1.clicked += () => { LoadButton(1); };
            sc2.clicked += () => { LoadButton(2); };
            sc3.clicked += () => { LoadButton(3); };
        }        

        void SetUIState(int state)
        {
            switch(state)
            {
                case 0: hud.gameObject.SetActive(false); Camera.main.enabled = false; menu.gameObject.SetActive(true); break;
                case 1: hud.gameObject.SetActive(true); Camera.main.enabled = true; menu.gameObject.SetActive(false); break;
            }

            uiState = state;
        }

        void LoadButton(int level)
        {
            // load player data.
            GameManager.Instance.dataManager.Load();
            
            am.LoadScene(level);
        }
    }
}
