using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagment
{
    public class CallOtherScene : MonoBehaviour
    {
        private ConnectToScene scene1;
        // Use this for initialization
        void Start()
        {
            scene1 = GameObject.Find("SceneConnection").GetComponent<ConnectToScene>();
            scene1.TestCall();
        }
    } 
}
