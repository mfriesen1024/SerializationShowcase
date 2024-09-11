using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    internal class UIManager : MonoBehaviour
    {
        // UI types
        [SerializeField] Canvas menu, hud;
        // Scene change/loaders.
        [SerializeField] GameObject ngo, lgo, sc1o, sc2o, sc3o;
        Button ng, lg, sc1, sc2, sc3;
        // Manual save
        [SerializeField] GameObject mso;
        Button ms;
        [SerializeField] TextMeshProUGUI hp, mp, xp, lvl, score, gmc;

        AreaManager am;
        public int UIState { get => uiState; set { SetUIState(value); } }
        int uiState;

        public void Init()
        {

            UIState = 0;

            ng = ngo.GetComponent<Button>();
            lg = lgo.GetComponent<Button>();
            sc1 = sc1o.GetComponent<Button>();
            sc2 = sc2o.GetComponent<Button>();
            sc3 = sc3o.GetComponent<Button>();
            ms = mso.GetComponent<Button>();

            // if new game, load level 1 with no questions asked.
            ng.onClick.AddListener(() => { am.LoadScene(1); });
            lg.onClick.AddListener(() => { GameManager.Instance.dataManager.Load(); am.LoadFromCheckpoint(GameManager.Instance.lastCheckpoint); });
            sc1.onClick.AddListener(() => { LoadButton(1); });
            sc2.onClick.AddListener(() => { LoadButton(2); });
            sc3.onClick.AddListener(() => { LoadButton(3); });
            ms.onClick.AddListener(() => { GameManager.Instance.dataManager.Save(); });

            am = GameManager.Instance.areaManager;
        }

        void SetUIState(int state)
        {
            switch (state)
            {
                case 0: hud.gameObject.SetActive(false); menu.gameObject.SetActive(true); break;
                case 1: hud.gameObject.SetActive(true); menu.gameObject.SetActive(false); break;
            }

            uiState = state;
        }

        void LoadButton(int level)
        {
            // load player data.
            GameManager.Instance.dataManager.Load();

            am.LoadScene(level);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) am.LoadScene(0); // press 1
            if (Input.GetKeyDown(KeyCode.Alpha2)) am.LoadScene(1); // press 2
            if (Input.GetKeyDown(KeyCode.Alpha3)) am.LoadScene(2); // press 3
            if (Input.GetKeyDown(KeyCode.Alpha4)) am.LoadScene(3); // press 4
        }

        public void TextUpdate(int ihp, int imp, int ixp, int ilvl, int iscore)
        {
            hp.text = $"HP: {ihp}";
            mp.text = $"MP: {imp}";
            xp.text = $"XP: {ixp}";
            lvl.text = $"Level: {ilvl}";
            score.text = $"Score: {iscore}";
            gmc.text = $"Game Managers: {GameManager.GMCount}";
        }
    }
}
