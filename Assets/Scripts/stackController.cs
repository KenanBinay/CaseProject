using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackController : MonoBehaviour
{
    public GameObject coinStack;
    public Transform parentCoin;
    private int coinStacked;
    Vector3 stackingPos;
    private float distanceZ, gapBetweenCoins;
    void Start()
    {
        coinStacked = 0;
    }

    void Update()
    {       
        if (coinStacked != coinHandler.coinCurrentVal)
        {
            if (gapBetweenCoins == 0) { gapBetweenCoins = transform.position.z - 0.3f; }
            else { gapBetweenCoins -= 0.3f; }

            stackingPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gapBetweenCoins);
            
            stackNewCoin(coinStack);
        }
        
    }

    void stackNewCoin(GameObject _stackingItem)
    {
        coinStacked++;
        GameObject childCoin = Instantiate(_stackingItem, stackingPos, transform.rotation, parentCoin);
        childCoin.name = "childCoinStack";

    }
}
