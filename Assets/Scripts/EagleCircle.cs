using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleCircle : MonoBehaviour
{
    public float speed;
    public float rotation =4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.left * rotation * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
  
    }
}
