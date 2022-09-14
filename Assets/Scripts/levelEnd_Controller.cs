using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd_Controller : MonoBehaviour
{
    [SerializeField] private GameObject rampEnd;
    [SerializeField] private Transform parentRamp;
    private Vector3 rampSpawnPos;

    private float gapBetweenRamps, heightBetwenRamps;
    int coinCount;
    void Start()
    {
        gapBetweenRamps = heightBetwenRamps = coinCount = 0;
    }

    void Update()
    {
        if (coinHandler.levelEnd)
        {
            if (gapBetweenRamps == 0 && heightBetwenRamps == 0) { gapBetweenRamps = rampEnd.transform.position.z + 1.67f; heightBetwenRamps = rampEnd.transform.position.y + 0.1f; }
            else { gapBetweenRamps += 1.67f; heightBetwenRamps += 0.05f; }

            if (coinCount != coinHandler.coinCurrentVal)
            {
                rampSpawnPos = new Vector3(rampEnd.transform.position.x, heightBetwenRamps, gapBetweenRamps);

                coinCount++;
                addRamp();
            }
        }
    }

    void addRamp()
    {
        GameObject childRamp = Instantiate(rampEnd, rampSpawnPos, transform.rotation, parentRamp.parent);
        childRamp.name = "childRamp";
    }
}
