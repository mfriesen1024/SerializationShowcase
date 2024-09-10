using Assets.Scripts.Managers;
using Assets.Scripts.Obj;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public StatManager statMan = new();

        [SerializeField] float lookMod = 10;
        [SerializeField] float moveMod = 5;
        [SerializeField] Rigidbody rb;
        public Camera cam;
        Vector2 look;
        Vector2 move;

        int tickNum = 0;

        // Start is called before the first frame update
        void Start()
        {
            GetCam();
            GetRB();

            void GetCam()
            {
                // Try to grab main camera. If one doesn't exist, make one.
                cam = Camera.main != null ? Camera.main : new GameObject("Camera").AddComponent<Camera>();
                // Snap cam position to our head.
                cam.transform.parent = transform;
                cam.transform.localPosition = new(0, 0.5f, 0);
            }

            void GetRB()
            {
                // if rb is null, try to fetch one, and if that fails, make one.
                if (rb == null) { Rigidbody getRB = GetComponent<Rigidbody>(); rb = getRB != null ? getRB : gameObject.AddComponent<Rigidbody>(); }
            }
        }

        // Update is called once per frame
        void Update()
        {
            LookUpdate();
            VelocityUpdate();
        }
        private void FixedUpdate()
        {
            Tick();
        }
        void LookUpdate()
        {
            float delta = Time.deltaTime;
            Vector3 camEA = cam.transform.eulerAngles;
            Vector3 playerEA = transform.eulerAngles;

            // Vertical component.
            float vComp = -look.y * delta * lookMod;
            // Keep vertical between 0 and 90 or 360 and 270.
            if (vComp > 180) { vComp = vComp < 270 ? vComp : 270; }
            else { vComp = vComp < 90 ? vComp : 90; }
            // Set value
            camEA = new(camEA.x + vComp, 0, 0);

            // Horizontal component.
            float hComp = look.x * delta * lookMod;
            playerEA.y = playerEA.y + hComp;

            // Set values.
            cam.transform.localEulerAngles = camEA;
            transform.localEulerAngles = playerEA;
        }
        void VelocityUpdate()
        {
            Vector3 moveVector = transform.forward * move.y + transform.right * move.x;
            Vector3 moveValue = moveVector * moveMod;
            // allow gravity to still work.
            moveValue.y = rb.velocity.y;
            // apply things.
            rb.velocity = moveValue;
        }

        /// <summary>
        /// Used to ensure stats are only ticked every 4 fixedupdate ticks.
        /// </summary>
        void Tick()
        {
            // Stats ticking. Ensure stats only tick every 4 fixedupdates.
            if (tickNum == 0) { statMan.StatsTick(); }

            // Every second, reset the tick count, save data, and update ui.
            tickNum++; if (tickNum == 20)
            {
                tickNum = 0;
                GameManager.Instance.dataManager.Save();
                GameManager.Instance.uiManager.TextUpdate(statMan.hp,statMan.mp,statMan.xp,statMan.Level,statMan.Score);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // track if we should hide the obj.
            bool shouldRemove = false;
            // If its a brick, mark the brick as collected.
            if (other.TryGetComponent(typeof(Brick), out Component b))
            {
                shouldRemove = true;
                statMan.bricks[((Brick)b).brickID] = true;
            }
            // if its a coin, add xp and score.
            if (other.TryGetComponent(typeof(Coin), out Component c))
            {
                shouldRemove = true;
                statMan.xp += 10;
                statMan.Score += 10;
            }
            // if its a checkpoint, track this as our last checkpoint.
            if (other.TryGetComponent(typeof(CheckpointComponent), out Component cc))
            {
                statMan.lastCheckpoint = ((CheckpointComponent)cc).data;
            }
            // if its a trap, deal damage to player.
            if(other.TryGetComponent(typeof(Trap),out Component t))
            {
                statMan.hp -= 8;
            }

            // if it should be disabled, disable it.
            if (shouldRemove) { other.gameObject.SetActive(false); }
        }

        void OnLook(InputValue value)
        {
            look = value.Get<Vector2>();
            Debug.Log(look);
        }

        void OnMove(InputValue value)
        {
            move = value.Get<Vector2>();
            Debug.Log(move);
        }

        void OnFire()
        {
            if (statMan.mp > 0) { Cast(); statMan.mp--; }
        }

        // this is used to cast the spell. split for my sanity.
        void Cast()
        {
            
        }
    }
}