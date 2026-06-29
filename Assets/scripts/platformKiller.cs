using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformKiller : MonoBehaviour
{

    public GameObject victim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (victim != null)
        {
            victim.gameObject.SetActive(false);
        }
    }
}
