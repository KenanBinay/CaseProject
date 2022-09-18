using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEndStair : MonoBehaviour
{
    public GameObject coinM, coinEnd;
    int myLine;
    bool destroyed;
    void Start()
    {
        myLine = levelEnd_Controller.stairLine;
        destroyed = false;
    }

   
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coinmain"))
        {
            
        }
        if (collision.gameObject.tag == "coinstack")
        {

        }
    }

}
