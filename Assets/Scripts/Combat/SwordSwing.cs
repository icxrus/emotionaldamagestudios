using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public GameObject Sword;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SwordSwinging());
        }
    }

    IEnumerator SwordSwinging()
    {
        Sword.GetComponent<Animator>().Play("SwordSwing");
        particles.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.0f);
        Sword.GetComponent<Animator>().Play("New State");
        particles.GetComponent<ParticleSystem>().Stop();
    }

    //Script from https://github.com/Noblob/SwordSwing/blob/main/SwordSwingScript.cs
}
