using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notSafe : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float moveDistance = 1f; //this is the distance 
       

    //this function shall be called from the signal handler
    void move()
    {
        float offset = Time.deltaTime* moveSpeed;
        transform.position += new Vector3(offset, 0f, 0f);
    }
}
