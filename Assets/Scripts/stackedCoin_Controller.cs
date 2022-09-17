using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class stackedCoin_Controller : MonoBehaviour
{
    public GameObject parentCoin;
    public Animator coinStackAnimHandle;
    Rigidbody rbStack;
    public static bool coinCollected, gameOverStacked, forceControl;
    public float jumpForce;
    float distanceBetween, lostCoinPosZ, distanceCut, targetPosZ;
    int myline;
    void Start()
    {
        forceControl = false;
        rbStack = GetComponent<Rigidbody>();
        parentCoin = GameObject.FindGameObjectWithTag("coinmain");

        myline = stackController.countLine;
        for (int j = 0; j < myline; j++) { distanceCut += -0.03f; }
        targetPosZ = gameObject.transform.position.z - distanceCut;

        //   Debug.Log(myline + " Line distanceCut: " + distanceCut);
    }

    void Update()
    {       
        if (coinHandler.gameOver) { if (forceControl) { addForce(); } }
        else
        {
            distanceBetween = parentCoin.transform.position.z - transform.position.z;

            transform.DOLocalMoveX(parentCoin.transform.position.x, distanceBetween);
           
            if (coinHandler.gameOver == false) { transform.DOLocalMoveZ(parentCoin.transform.position.z - distanceCut, myline); }
            if (coinMovement.leftTurn) { transform.DOLocalRotate(new Vector3(0, -130, 0), distanceBetween); }
            if (coinMovement.rightTurn) { transform.DOLocalRotate(new Vector3(0, -50, 0), distanceBetween); }
            if (coinMovement.isDraging == false) { transform.DOLocalRotate(new Vector3(0, -90, 0), 1); }
        }

        if (coinHandler.levelEnd)
        {

        }

        if (coinCollected)
        {            
            StartCoroutine(waitDelay());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            coinHandler.coinCurrentVal--;
            lostCoinPosZ = transform.position.z;
            
            Debug.Log("lost coin pos: " + lostCoinPosZ);
            Destroy(gameObject);
        }    
        if (collision.gameObject.tag == "endRamp")
        {
            if (coinHandler.levelEndCoinVal == myline) { StartCoroutine(waitForCoinDrop()); }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "falltrigger")
        {
            coinHandler.coinCurrentVal--;
            Destroy(gameObject);
        }
    }
    void addForce()
    {
        rbStack.constraints = RigidbodyConstraints.None;
        rbStack.AddForce(new Vector3(2, 50, 2));
        forceControl = false;
    }

    private IEnumerator waitDelay()
    {
        yield return new WaitForSeconds(distanceBetween);
        rbStack.AddForce(new Vector3(0, 3, 0) * jumpForce);
        coinCollected = false;
    }

    IEnumerator waitForCoinDrop()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
