using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AD0260
{
    public class WaitToExecute : MonoBehaviour
    {
        // do using state machine
        public string _demoCounter;
        [SerializeField] private float number;

        public float _waitfor = 3;
        public int _slow = 20;
        
        void FixedUpdate()
        {
            if(_doWait == false)
            {
                number += (1f / _slow);
                _demoCounter = "Time: " + number;
            }
        }
        public void Timer()
        {
            if(_doWait == true)
            {
                _waitfor -= Time.deltaTime;
            }
        }
        public bool _doWait = false;

        private void Update()
        {
            // do wait on key press.
            if (Input.GetKeyDown(KeyCode.H))
            {
                _doWait = true;
            }
            // Reset count
            if (number >= 20) { number = 0f; }
            Timer();
            if (_waitfor <= 0) 
            {
                _waitfor = 3;
                _doWait = false;
            }
        }
    } 
}
