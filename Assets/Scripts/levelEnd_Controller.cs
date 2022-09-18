using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd_Controller : MonoBehaviour
{
    [SerializeField] private GameObject rampEnd;
    [SerializeField] private Transform parentRamp;
    private Vector3 rampSpawnPos;

    public static int stairLine;
    public static float gapBetweenRamps, heightBetwenRamps, distanceRamps_Z;
    int coinCount;
    void Start()
    {
        gapBetweenRamps = heightBetwenRamps = stairLine = coinCount = 0;
    }

    void Update()
    {
        if (coinHandler.levelEnd && coinMovement.flip == false)
        {
            if (coinHandler.coinCurrentVal <= 0) { distanceRamps_Z = rampEnd.transform.position.z; ; }
            if (gapBetweenRamps == 0 && heightBetwenRamps == 0) { gapBetweenRamps = rampEnd.transform.position.z; heightBetwenRamps = rampEnd.transform.position.y; distanceRamps_Z = gapBetweenRamps; }
            else
            {
                gapBetweenRamps += 1.67f; heightBetwenRamps += 0.05f;

                if (coinCount != coinHandler.coinCurrentVal)
                {
                    rampSpawnPos = new Vector3(rampEnd.transform.position.x, heightBetwenRamps, gapBetweenRamps);

                    coinCount++;
                    distanceRamps_Z = gapBetweenRamps;

                    addRamp();
                }
            }
        }
    }

    void addRamp()
    {
        stairLine++;
        Debug.Log("lastStairPosZ: " + distanceRamps_Z);
        GameObject childStair = Instantiate(rampEnd, rampSpawnPos, transform.rotation, parentRamp.parent);
        childStair.name = "childStair";
    }
}
