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
    float distanceToParent;

    void Start()
    {
        rbStack = GetComponent<Rigidbody>();
        parentCoin = GameObject.FindGameObjectWithTag("coinmain");
    }

    void Update()
    {
        distanceToParent = parentCoin.transform.position.z - transform.position.z;

        if (coinCollected)
        {          
            StartCoroutine(waitDelay());
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
