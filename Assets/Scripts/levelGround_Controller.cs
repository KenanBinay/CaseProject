using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGround_Controller : MonoBehaviour
{
    [SerializeField] GameObject axe, axe2, wipeOutGround, wipeOutGround2, wipeOutAir, wipeOutAir2;
    int randObstacleSelect;
    void Start()
    {
        axe.SetActive(false);
        axe2.SetActive(false);
        wipeOutGround.SetActive(false);
        wipeOutGround2.SetActive(false);
        wipeOutAir.SetActive(false);
        wipeOutAir2.SetActive(false);

        int[] obstacleNumbs = { 1, 2, 3 };
        randObstacleSelect = obstacleNumbs[Random.Range(0, obstacleNumbs.Length)];

        switch (randObstacleSelect)
        {
            case 1:
                axe.SetActive(true);
                wipeOutAir.SetActive(true);                
                break;
            case 2:
                wipeOutGround.SetActive(true);
                wipeOutAir.SetActive(true);
                break;
            case 3:
                wipeOutAir.SetActive(true);
                axe.SetActive(true);
                break;
        }
    }

    void Update()
    {
        
    }
}
