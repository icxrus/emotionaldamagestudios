using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSleep : MonoBehaviour
{
    [SerializeField] private Animator sleep;
    // Start is called before the first frame update
    void Start()
    {
        sleep.SetBool("Sleep", true);
    }
}
