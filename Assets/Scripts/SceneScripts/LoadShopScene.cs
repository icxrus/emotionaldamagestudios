using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AD0260
{
    public class LoadShopScene : MonoBehaviour
    {
        public string SceneName;
        public void LoadScene()
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
