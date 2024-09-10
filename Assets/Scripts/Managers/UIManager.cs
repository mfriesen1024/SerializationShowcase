using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    internal class UIManager:MonoBehaviour
    {
        [SerializeField]Canvas menu, hud;
        [SerializeField]GameObject ngo,lgo,sc1o,sc2o,sc3o;
        Button ng, lg, sc1, sc2, sc3;
        AreaManager am;
        public int UIState { get => uiState; set { SetUIState(value); } }
        int uiState;

        public void Init()
        {

            UIState = 0;

            ng = ngo.GetComponent<Button>();
            lg = lgo.GetComponent<Button> ();
            sc1 = sc1o.GetComponent<Button>();
            sc2 = sc2o.GetComponent<Button>();
            sc3 = sc3o.GetComponent<Button>();

            // if new game, load level 1 with no questions asked.
            ng.onClick.AddListener(() => { am.LoadScene(1); });
            lg.onClick.AddListener(() => { GameManager.Instance.dataManager.Load(); am.LoadFromCheckpoint(GameManager.Instance.lastCheckpoint); });
            sc1.onClick.AddListener(() => { LoadButton(1); });
            sc2.onClick.AddListener(() => { LoadButton(2); });
            sc3.onClick.AddListener(() => { LoadButton(3); });

            am = GameManager.Instance.areaManager;
        }

        void SetUIState(int state)
        {
            switch(state)
            {
                case 0: hud.gameObject.SetActive(false); if (Camera.main != null) { Camera.main.enabled = false; } menu.gameObject.SetActive(true); break;
                case 1: hud.gameObject.SetActive(true); if (Camera.main != null) { Camera.main.enabled = false; } menu.gameObject.SetActive(false); break;
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
