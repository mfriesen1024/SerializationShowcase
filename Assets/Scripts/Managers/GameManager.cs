using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    internal class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Represents the player.
        /// </summary>
        PlayerController playerController;
        /// <summary>
        /// Used to save data.
        /// </summary>
        public DataManager dataManager = new DataManager();
        /// <summary>
        /// Used to manage what area player is in.
        /// </summary>
        public AreaManager areaManager = new AreaManager();
        public UIManager uiManager;

        public static GameManager Instance;

        private void Start()
        {
            FindPlayer();
            // This has to be in inspector, we can't just make it.
            uiManager = GetComponent<UIManager>();

            void FindPlayer()
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player == null) { player = new GameObject("Player"); }
                playerController = player.GetComponent<PlayerController>();
                if (playerController == null) { playerController = player.AddComponent<PlayerController>(); }

                playerController.transform.parent = transform;
            }

            DontDestroyOnLoad(gameObject);
        }


        private void Update()
        {

        }

        private void FixedUpdate()
        {

        }
    }
}
