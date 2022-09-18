using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f, endSmootSpeed;
    public Vector3 offset, offsetEnd;

    public static bool camMovedFinish;

    private void Start()
    {
        camMovedFinish = false;
    }

    void Update()
    {
        if (coinHandler.gameOver == false && coinMovement.flip == false)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = SmoothedPosition;
        }

        if (coinHandler.levelEnd && coinHandler.levelEndCoinVal == coinHandler.coinCurrentVal)
        {
            Vector3 desiredPositionEnd = new Vector3(target.position.x + offsetEnd.x, target.position.y + offsetEnd.y, target.position.z + offsetEnd.z);
            Vector3 SmoothedPositionEnd = Vector3.Lerp(transform.position, desiredPositionEnd, endSmootSpeed);

            transform.position = SmoothedPositionEnd;
            if (transform.position.y >= 3) { transform.DOLookAt(target.position, 0.25f); }        
        }
    }
}
