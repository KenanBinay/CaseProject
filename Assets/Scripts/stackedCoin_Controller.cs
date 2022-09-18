using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class stackedCoin_Controller : MonoBehaviour
{
    GameObject parentCoin;
    Rigidbody rbStack;
    public static bool coinCollected, gameOverStacked;
    public float jumpForce;
    float distanceBetween, lostCoinPosZ, distanceCut, targetPosZ;
    public static float endDistanceCut;
    int myline;
    bool EndCoinDrop, forceControl;
    void Start()
    {
        forceControl = EndCoinDrop = false;
        rbStack = GetComponent<Rigidbody>();
        parentCoin = GameObject.FindGameObjectWithTag("coinmain");

        myline = stackController.countLine;
        for (int j = 0; j < myline; j++) { distanceCut += -0.03f; }
        targetPosZ = gameObject.transform.position.z - distanceCut;

        endDistanceCut = 0;
        //   Debug.Log(myline + " Line distanceCut: " + distanceCut);
    }

    void Update()
    {
        if (coinHandler.gameOver) { if (forceControl == false) { addForce(); } }
        else
        {
            distanceBetween = parentCoin.transform.position.z - transform.position.z;
            float x = endDistanceCut + distanceCut;
            if (EndCoinDrop == false)
            {
                transform.DOLocalMoveZ(parentCoin.transform.position.z - x, myline);
                transform.DOLocalMoveX(parentCoin.transform.position.x, distanceBetween);
                transform.DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
            }

            if (coinMovement.leftTurn) { transform.DOLocalRotate(new Vector3(0, -130, 0), distanceBetween); }
            if (coinMovement.rightTurn) { transform.DOLocalRotate(new Vector3(0, -50, 0), distanceBetween); }

        }

        if (coinCollected) { StartCoroutine(waitDelay()); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            coinHandler.coinCurrentVal--;
            lostCoinPosZ = transform.position.z;
            
            Debug.Log("lost coin line: " + myline);

            Destroy(gameObject);
        }    
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "falltrigger")
        {
            coinHandler.coinCurrentVal--;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "endRamp")
        {
            if (EndCoinDrop == false)
            {
                EndCoinDrop = true;
                rbStack.constraints = RigidbodyConstraints.None;
                transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z - 1);
                Destroy(other.gameObject);
                rbStack.AddForce(Random.Range(-4, 4), 5, 0);
            }
        }
    }

    void addForce()
    {
        rbStack.constraints = RigidbodyConstraints.None;
        rbStack.AddForce(Random.Range(-4, 4), 5, 0);

        forceControl = true;
    }

    private IEnumerator waitDelay()
    {
        yield return new WaitForSeconds(distanceBetween);
        rbStack.AddForce(new Vector3(0, 0.25f, 0));
   //     if (rbStack.transform.position.y < 1.5f) { rbStack.AddForce(new Vector3(0, 1, 0) * jumpForce); }
        coinCollected = false;
    }
}
