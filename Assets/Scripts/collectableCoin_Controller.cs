using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableCoin_Controller : MonoBehaviour
{
    void Start()
    {
        gameObject.tag = "coincollect";
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coinmain")
        {
            Destroy(gameObject);
        }
    }
}
