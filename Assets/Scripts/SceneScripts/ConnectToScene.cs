using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagment
{
    public class ConnectToScene : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
        }
        public void TestCall()
        {
            Debug.Log("Connected to Shops");
        }
    }

}