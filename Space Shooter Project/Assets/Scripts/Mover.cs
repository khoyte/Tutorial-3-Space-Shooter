using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        // gets rigidbody component
        rb = GetComponent<Rigidbody>();
        // movement, direction, and speed of beam
        rb.velocity = transform.forward * speed;
    }
}
