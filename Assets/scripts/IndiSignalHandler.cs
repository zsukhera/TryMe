using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiSignalHandler : MonoBehaviour
{
    //this script shall receive an object and then call it to move
    //this is different from the original signal handler that directs all the objects to move
    // Start is called before the first frame update
    public GameObject notsafeGround;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        notsafeGround.GetComponent<notSafe>().move();
    }
}
