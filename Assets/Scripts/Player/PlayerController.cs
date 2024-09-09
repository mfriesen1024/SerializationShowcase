using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public StatManager statMan = new();

        Vector2 look;
        Vector2 move;

        int tickNum = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        

        /// <summary>
        /// Used to ensure stats are only ticked every 4 fixedupdate ticks.
        /// </summary>
        void Tick()
        {
            // Stats ticking. Ensure stats only tick every 4 fixedupdates.
            if (tickNum == 0) { statMan.StatsTick(); }

            // Every second, reset the tick count and save data.
            tickNum++; if (tickNum == 20)
            {
                tickNum = 0;
                GameManager.Instance.dm.Save();
            }
        }

        void OnLook(InputValue value)
        {
            look = value.Get<Vector2>();
        }

        void OnMove(InputValue value)
        {
            move = value.Get<Vector2>();
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