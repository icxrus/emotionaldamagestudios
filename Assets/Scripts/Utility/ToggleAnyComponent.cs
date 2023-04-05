using UnityEngine;

public class ToggleAnyComponent : MonoBehaviour
{
    [SerializeField] private GameObject _ToggleableObject;
    public void WhoYjaGonnaCall()
    {
        if (_ToggleableObject.activeSelf == true)
        {
            _ToggleableObject.SetActive(false);
        }
        else if (_ToggleableObject.activeSelf == false)
        {
            _ToggleableObject.SetActive(true);
        }
    }
}
