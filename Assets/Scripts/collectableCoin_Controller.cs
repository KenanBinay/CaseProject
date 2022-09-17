using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableCoin_Controller : MonoBehaviour
{
    GameObject collectable;
    void Start()
    {
        collectable.GetComponent<GameObject>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coinmain")
        {
            Destroy(collectable);
        }    
    }
}
