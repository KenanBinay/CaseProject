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
            Debug.Log("LevelEnd");
        }
        if (other.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            Debug.Log("GameOver");
        }
        if (other.gameObject.CompareTag("coincollect"))
        {
            coinCurrentVal++;
            stackedCoin_Controller.coinCollected = true;
            Debug.Log("CoinCollected: " + coinCurrentVal);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
