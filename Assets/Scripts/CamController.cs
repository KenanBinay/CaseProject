using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f, followSpeed, lvlEndSmoothSpeed, CamZoomSmooth, boosts_smoothSpeed;
    public Vector3 offset, lvlEndOffset, lookLvlEnd, offset_speedUp;

    public static bool camMovedFinish;
    bool delayWaited;

    private void Start()
    {
        camMovedFinish = false;
    }

    void Update()
    {
        if (coinHandler.gameOver == false)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = SmoothedPosition;
        }    
    }

    public IEnumerator DelayForLvlEndCam()
    {
        yield return new WaitForSeconds(0.5f);

        delayWaited = true;
    }
}
