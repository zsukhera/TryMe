using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeSaw : MonoBehaviour
{

    public GameObject saw;
    // Start is called before the first frame update
    void Start()
    {
        saw = GameObject.Find("sawTrap");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = saw.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
