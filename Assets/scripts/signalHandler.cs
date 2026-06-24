using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signalHandler : MonoBehaviour
{

    GameObject unsafeGround;    //this shall receive a unsafegground tile or a 
    //set of tiles and accordingly call their move function
    
    // Start is called before the first frame update
    void Start()
    {
        unsafeGround = GameObject.Find("notSafeGround");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("notSafeGround").GetComponent<notSafe>().move();
    }
}
