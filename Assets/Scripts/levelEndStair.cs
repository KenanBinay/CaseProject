using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEndStair : MonoBehaviour
{
    int myLine;

    void Start()
    {
        myLine = levelEnd_Controller.stairLine;
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
