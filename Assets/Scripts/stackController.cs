using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackController : MonoBehaviour
{
    public GameObject coinStack;
    public Transform parentCoin;
    public static bool coinCollected_Stack;
    Vector3 stackingPos;
    private float gapBetweenCoins;
    void Start()
    {
        coinCollected_Stack = false;
    }

    void Update()
    {       
        if (coinCollected_Stack)
        {
            if (gapBetweenCoins == 0) { gapBetweenCoins = transform.localPosition.z - 0.3f; }
            else { gapBetweenCoins -= 0.3f; }

            stackingPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gapBetweenCoins);
        
            stackNewCoin(coinStack);
        }
        
    }

    void stackNewCoin(GameObject _stackingItem)
    {
        GameObject childCoin = Instantiate(_stackingItem, stackingPos, transform.rotation);
        childCoin.name = "childCoinStack";
        coinCollected_Stack = false;
    }
}
