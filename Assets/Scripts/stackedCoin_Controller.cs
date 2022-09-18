using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class stackedCoin_Controller : MonoBehaviour
{
    public GameObject coinEnd;
    GameObject parentCoin;
    Rigidbody rbStack;
    public static bool coinCollected, gameOverStacked, forceControl;
    public float jumpForce;
    float distanceBetween, lostCoinPosZ, distanceCut, targetPosZ;
    public static float endDistanceCut;
    int myline;
    bool EndCoinDrop;
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
        if (coinHandler.gameOver) { if (forceControl) { addForce(); } }
        else
        {
            distanceBetween = parentCoin.transform.position.z - transform.position.z;

            if (EndCoinDrop == false)
            {
                transform.DOLocalMoveZ(parentCoin.transform.position.z - distanceCut + endDistanceCut, myline);
                transform.DOLocalMoveX(parentCoin.transform.position.x, distanceBetween);

                transform.DOLocalRotate(new Vector3(0, -90, 0), 1);
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
                Destroy(other.gameObject);
                rbStack.constraints = RigidbodyConstraints.None;
                rbStack.AddForce(new Vector3(-2f, 1.2f, 0));
            }

     //       Destroy(gameObject); 
        }
    }

    void addForce()
    {
        rbStack.constraints = RigidbodyConstraints.None;
        rbStack.AddForce(new Vector3(2, 1, 2));
        forceControl = false;
    }

    private IEnumerator waitDelay()
    {
        yield return new WaitForSeconds(distanceBetween);
        rbStack.AddForce(new Vector3(0, 1f, 0) * jumpForce);
        coinCollected = false;
    }
}
