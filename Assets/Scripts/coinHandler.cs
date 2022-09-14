using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinHandler : MonoBehaviour
{
    Rigidbody coinRb;
    public static bool levelEnd, gameOver, coinsDroped;
    public static int coinCurrentVal, levelEndCoinVal;
    void Start()
    {
        coinRb = GetComponent<Rigidbody>();
        coinCurrentVal = levelEndCoinVal = 0;
        levelEnd = gameOver = coinsDroped = false;
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("endEnter"))
        {
            levelEnd = true;
            Debug.Log("LevelEnd");
        }
        if (other.gameObject.CompareTag("coincollect"))
        {
            coinCurrentVal++;
            stackedCoin_Controller.coinCollected = true;
            Debug.Log("CoinCollected: " + coinCurrentVal);
        }
        if (other.gameObject.CompareTag("endRamp"))
        {
            if (levelEndCoinVal != coinCurrentVal) { levelEndCoinVal++; coinsDroped = true; }        
            Debug.Log("levelEnd Coin Drop: " + levelEndCoinVal);
        }
        if (other.gameObject.CompareTag("falltrigger"))
        {
            gameOver = true;
            coinRb.constraints = RigidbodyConstraints.None;
            Debug.Log("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            coinRb.constraints = RigidbodyConstraints.None;
            coinRb.AddForce(new Vector3(2, 3, 2));
            Debug.Log("GameOver");
        }
    }
}
