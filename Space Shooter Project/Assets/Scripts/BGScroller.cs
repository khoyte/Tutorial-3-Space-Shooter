using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        // where background starts in Unity
        startPosition = transform.position;
    }
    void Update()
    {
        // repeats background with tile size z and controlled by scrolling speed
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        // moving background with scroll speed
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
