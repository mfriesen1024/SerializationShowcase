using Assets.Scripts.Obj;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    internal partial class GameManager : MonoBehaviour
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

        /// <summary>
        /// The singleton instance of the GM.
        /// </summary>
        public static GameManager Instance;
        /// <summary>
        /// Number of instantiated GMs
        /// </summary>
        public static int GMCount = 0;

        public CheckpointInfo lastCheckpoint { get { return PlayerController.statMan.lastCheckpoint; } }

        /// <summary>
        /// Used to save every minute.
        /// </summary>
        TickCounter saveTimer;

        private void Start()
        {
            // Raise the gm count before we do anything else.
            GMCount++;
            // If instance isn't null, un-count ourselves, destroy this instance and don't run anything else.
            // Otherwise, we should be instance, don't uncount ourselves, and dont destroy on load.
            if (Instance != null) { GMCount--; Destroy(gameObject); return; }
            else { Instance = this; DontDestroyOnLoad(gameObject); }

            // Make player.
            playerController = Instantiate(pcTemplate).GetComponent<PlayerController>();
            PlayerController.transform.parent = transform;

            // This has to be in inspector, we can't just make it.
            uiManager = GetComponent<UIManager>();

            Init();

            // If we got this far, we're obviously the singleton instance, so setup don't destroy on load.
            // Idk if we need to do this after everything else.
            //DontDestroyOnLoad(gameObject);
        }

        // Initialize things here so we can control initialization order.
        void Init()
        {
            dataManager.Init();
            uiManager.Init();

            saveTimer = new TickCounter() { interval = 1200, action = () => { dataManager.Save(); Debug.Log("Autosaved!"); } };
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {

        }
    }
}
