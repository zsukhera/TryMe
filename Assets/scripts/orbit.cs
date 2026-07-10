using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{
    public Transform barycentre;    //the platform shall orbit around this
    public float orbitSpeed = 30f;   // Degrees per second
    public Vector3 orbitAxis = Vector3.forward; // Z-axis for 2D
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        performOrbit();
    }

    private void performOrbit()
    {
        if (barycentre == null) return;
        transform.RotateAround(barycentre.position,orbitAxis,orbitSpeed * Time.deltaTime);
        transform.rotation = initialRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
