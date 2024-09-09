using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    internal class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Represents the player.
        /// </summary>
        public PlayerController playerController {  get; private set; }
        /// <summary>
        /// Used to save data.
        /// </summary>
        public DataManager dataManager { get; private set; } = new DataManager();
        /// <summary>
        /// Used to manage what area player is in.
        /// </summary>
        public AreaManager areaManager { get; private set; } = new AreaManager();
        public UIManager uiManager {  get; private set; }

        public static GameManager Instance;

        private void Start()
        {
            // If instance isn't null, destroy this instance and don't run anything else.
            // Otherwise, we should be instance.
            if (Instance != null) { Destroy(gameObject); return; }
            else { Instance = this; }

            FindPlayer();
            // This has to be in inspector, we can't just make it.
            uiManager = GetComponent<UIManager>();

            void FindPlayer()
            {
                // Find or create the player and its controller script.
                GameObject player = GameObject.FindWithTag("Player");
                if (player == null) { player = new GameObject("Player"); }
                playerController = player.GetComponent<PlayerController>();
                if (playerController == null) { playerController = player.AddComponent<PlayerController>(); }

                playerController.transform.parent = transform;
            }

            dataManager.Init();

            // If we got this far, we're obviously the singleton instance, so setup don't destroy on load.
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
