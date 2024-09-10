using Assets.Scripts.Obj;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    internal class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Represents the player.
        /// </summary>
        public PlayerController PlayerController { get => playerController; }
        private PlayerController playerController;
        [SerializeField] GameObject pcTemplate;
        /// <summary>
        /// Used to save data.
        /// </summary>
        public DataManager dataManager { get; private set; } = new DataManager();
        /// <summary>
        /// Used to manage what area player is in.
        /// </summary>
        public AreaManager areaManager { get; private set; } = new AreaManager();
        public UIManager uiManager { get; private set; }

        public static GameManager Instance;

        public CheckpointInfo lastCheckpoint { get { return PlayerController.statMan.lastCheckpoint; } }


        private void Start()
        {
            // If instance isn't null, destroy this instance and don't run anything else.
            // Otherwise, we should be instance.
            if (Instance != null) { Destroy(gameObject); return; }
            else { Instance = this; }

            // Make player.
            playerController = Instantiate(pcTemplate).GetComponent<PlayerController>();
            PlayerController.transform.parent = transform;

            // This has to be in inspector, we can't just make it.
            uiManager = GetComponent<UIManager>();

            Init();

            // If we got this far, we're obviously the singleton instance, so setup don't destroy on load.
            DontDestroyOnLoad(gameObject);
        }

        // Initialize things here so we can control initialization order.
        void Init()
        {
            dataManager.Init();
            uiManager.Init();
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {

        }
    }
}
