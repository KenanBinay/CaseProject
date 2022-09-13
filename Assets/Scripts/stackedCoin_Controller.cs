using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackedCoin_Controller : MonoBehaviour
{
    public GameObject parentCoin;
    public Animator coinStackAnimHandle;
    public static bool coinCollected;
    float distanceToParent;
    void Start()
    {
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
        coinStackAnimHandle.SetTrigger("coinCollected");
        coinCollected = false;
    }
}
