using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinHandler : MonoBehaviour
{
    Rigidbody coinRb;
    GameObject collectable;
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
            Destroy(other.gameObject);
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
        if (other.gameObject.CompareTag("endRamp"))
        {
            if (levelEndCoinVal != coinCurrentVal) { levelEndCoinVal++; }
            stackController.coinCollected_Stack = false;
            stackedCoin_Controller.endDistanceCut += 0.03f;
            Debug.Log("levelEnd Coin Drop: " + levelEndCoinVal);
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
    }
}
