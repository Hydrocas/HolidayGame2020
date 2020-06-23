///-----------------------------------------------------------------
/// Author : Clément VIEILLY
/// Date : 23/06/2020 12:14
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.HolidayGame.MoveExperience.Managers
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager instance;
        public static InputManager Instance { get { return instance; } }
        private Controller _controller;
        public Controller Controller { get => _controller; }

        private void Awake()
        {
            if(instance)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            _controller = new Controller(); 
        }

        private void Update()
        {
            _controller.Update(); 
        }
    }
}