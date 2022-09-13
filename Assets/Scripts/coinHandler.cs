using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinHandler : MonoBehaviour
{
    public static bool levelEnd, gameOver;
    public static int coinCurrentVal;
    void Start()
    {
        coinCurrentVal = 0;
        levelEnd = gameOver = false;
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("levelEnd"))
        {
            levelEnd = true;
        }
        if (other.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
        }
        if (other.gameObject.CompareTag("coincollect"))
        {
            coinCurrentVal++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
