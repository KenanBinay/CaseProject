using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class stackedCoin_Controller : MonoBehaviour
{
    public GameObject parentCoin;
    public Animator coinStackAnimHandle;
    Rigidbody rbStack;
    public static bool coinCollected, gameOverStacked;
    public float jumpForce;
    float distanceToParent,lostCoinPosZ;

    void Start()
    {
        rbStack = GetComponent<Rigidbody>();
        parentCoin = GameObject.FindGameObjectWithTag("coinmain");
    }

    void Update()
    {       
        if (coinHandler.gameOver) { rbStack.constraints = RigidbodyConstraints.None; }
        else
        {
            distanceToParent = parentCoin.transform.position.z - transform.position.z;
            Vector3 Direction = new Vector3(parentCoin.transform.position.x, transform.position.y, transform.position.z);
            transform.localPosition += new Vector3(0, 0, 1) * 1.7f * Time.deltaTime;
            transform.DOLocalMoveX(parentCoin.transform.position.x, distanceToParent);
            transform.DOLocalRotate(new Vector3(0, 90, 0), 1);
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
    }

    private IEnumerator waitDelay()
    {
        yield return new WaitForSeconds(distanceToParent);
        rbStack.AddForce(new Vector3(0, 3, 0) * jumpForce);
        coinCollected = false;
    }
}
