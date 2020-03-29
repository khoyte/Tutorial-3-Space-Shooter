using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    // method that controls clamp for organization
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private float nextFire;
    private Rigidbody rb;

    private void Start()
    {
        // getting rigidbody component
        rb = GetComponent<Rigidbody>();
        // getting audio source component
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // when the fire button is pressed and the time for the next shot is greater than the time passed, a shot is spawned
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            // calculates nextFire with time passed and the rate of fire
            nextFire = Time.time + fireRate;
            // creates a shot
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            // plays sound of shot
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        // getting input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // player speed
        rb.velocity = movement * speed;

        // controls player to stay inside boundaries
        rb.position = new Vector3
            (
                // x
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                // y
                0.0f,
                // z
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        // tilt of player ship
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
