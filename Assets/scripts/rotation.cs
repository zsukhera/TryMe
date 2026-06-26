using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 360f; // Degrees per second

    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    //letting this be here for now
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}