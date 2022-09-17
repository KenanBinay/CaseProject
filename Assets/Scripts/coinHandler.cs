using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinHandler : MonoBehaviour
{
    Rigidbody coinRb;
    GameObject coinCollectedObject;
    public static bool levelEnd, gameOver;
    public static int coinCurrentVal, levelEndCoinVal;
    void Start()
    {
        coinRb = GetComponent<Rigidbody>();
        coinCurrentVal = levelEndCoinVal = 0;
        levelEnd = gameOver = false;
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
            stackedCoin_Controller.coinCollected = stackController.coinCollected_Stack = true;
            Debug.Log("CoinCollected: " + coinCurrentVal);
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
            gameOver = stackedCoin_Controller.forceControl = true;
            coinRb.constraints = RigidbodyConstraints.None;
            coinRb.AddForce(new Vector3(2, 10, 2));
            Debug.Log("GameOver");
        }
        if (collision.gameObject.CompareTag("endRamp"))
        {
            if (levelEndCoinVal != coinCurrentVal) { levelEndCoinVal++;}           
            Debug.Log("levelEnd Coin Drop: " + levelEndCoinVal);
        }
    }
}
