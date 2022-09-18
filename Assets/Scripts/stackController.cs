using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackController : MonoBehaviour
{
    public GameObject coinStack;
    public static bool coinCollected_Stack;
    Vector3 stackingPos;
    public static float gapBetweenCoins;
    public static int countLine;

    void Start()
    {
        coinCollected_Stack = false;
    }

    void Update()
    {
        if (coinHandler.coinCurrentVal <= 0) { countLine = 0; }
        if (coinCollected_Stack)
        {
            countLine++;

        /*    if (gapBetweenCoins == 0) { gapBetweenCoins = transform.localPosition.z - 0.3f; }
            else { gapBetweenCoins -= 0.3f; }
       */
            Debug.Log(countLine + " Line Coin");

            stackingPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 0.3f);
        
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
