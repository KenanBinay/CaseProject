using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wipeOut_Controller : MonoBehaviour
{
    float posX;
    void Start()
    {
        if (transform.localRotation.x >= 0)
        {
            posX = Random.Range(2.9f, 6f);
            transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localRotation.x < 0)
        {
            posX = Random.Range(-2.55f, -5.5f);
            transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
    }
}
