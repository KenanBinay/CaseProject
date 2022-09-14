using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackedCoin_Controller : MonoBehaviour
{
    public GameObject parentCoin;
    public Animator coinStackAnimHandle;
    Rigidbody rbStack;
    public static bool coinCollected;
    public float jumpForce;
    float distanceToParent,lostCoinPosZ;

    void Start()
    {
        rbStack = GetComponent<Rigidbody>();
        parentCoin = GameObject.FindGameObjectWithTag("coinmain");
    }

    void Update()
    {
        distanceToParent = parentCoin.transform.position.z - transform.position.z;
        var parentDirectionX = new Vector3(parentCoin.transform.position.x, transform.position.y, transform.position.z);

        if (coinHandler.gameOver) { rbStack.constraints = RigidbodyConstraints.None; }
        if (transform.position.x != parentCoin.transform.position.x) { transform.Translate(parentDirectionX * 5 * Time.deltaTime); }

        if (coinCollected)
        {          
            StartCoroutine(waitDelay());
        }

  //      if (transform.position.z < lostCoinPosZ) { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.3f); }
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
        //   coinStackAnimHandle.SetTrigger("coinCollected");
        rbStack.AddForce(new Vector3(0, 3, 0) * jumpForce);
        coinCollected = false;
    }
}
