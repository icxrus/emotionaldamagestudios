using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleCircle : MonoBehaviour
{
    [SerializeField] GameObject eagle;
    [SerializeField] GameObject empty;

    // Positive numbers make the eagle fly clockwise and negative numbers make it move counter-clockwise
    [SerializeField] float direction = -1;
    //You can change the speed of the eagle from the inspector.
    [SerializeField] float flySpeed = 60;
    void Update() =>
       transform.RotateAround(empty.transform.position,
           new Vector3(0, direction, 0), flySpeed * Time.deltaTime);

    //Source: https://stackoverflow.com/questions/38724961/how-to-make-a-gameobject-rotate-around-another-gameobject-in-unity-in-the-rotati
}
