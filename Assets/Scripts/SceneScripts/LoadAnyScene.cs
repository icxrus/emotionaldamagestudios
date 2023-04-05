using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAnyScene : MonoBehaviour
{
    [SerializeField] private string SceneName;

        public void LoadSceneAddative()
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }
        public void LoadSceneSingle()
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
}
