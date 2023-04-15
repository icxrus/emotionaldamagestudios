using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private void OnTriggerEnter(Collider other)
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
