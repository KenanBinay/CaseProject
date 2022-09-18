using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject[] levelPrefabs;

    private Vector3 spawnpoint;
    public float posZ_1, posZ_2, posZ_3;
    float randomPosZ, usedPosZ1, usedPosZ2, usedPosZ3, usedPosZ;
    float[] posNumbZ = { 6.5f, 17.44f, 28.5f };
    private int levelCurrent, randType, levelMapControl, baseAdded, baseNumb;
    int j;
    void Start()
    {
        randomPosZ = usedPosZ1 = usedPosZ2 = usedPosZ3 = usedPosZ = 0;
        j = 2;
        int[] levelType = { 1, 2, 3, 4 };
        levelCurrent = levelType[Random.Range(0, levelType.Length)];

        int[] levelDesignRand = { 1, 2, 3 };
        randType = levelType[Random.Range(0, levelType.Length)];

        Debug.Log("levelCurrent: " + levelCurrent + " || RandType: " + randType);

        for (int i = 0; i < j; i += 1)
        {
            randomPosZ = posNumbZ[Random.Range(0, posNumbZ.Length)];
            if (randomPosZ == 6.5f) { usedPosZ1 = 6.5f; }
            if (randomPosZ == 17.44f) { usedPosZ2 = 17.44f; }
            if (randomPosZ == 28.5f) { usedPosZ3 = 28.5f; }

            if (usedPosZ == randomPosZ) { j++; }
            else
            {
                spawnpoint = new Vector3(-0.06f, 1.58f, randomPosZ);
                usedPosZ = randomPosZ;

                int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
                baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];

                GameObject baseObject = levelPrefabs[baseNumb];
                Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);
            }
        }

        if (usedPosZ1 == 0)
        {
            spawnpoint = new Vector3(-0.06f, 1.58f, 6.5f);

            int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
            baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];

            GameObject baseObject = levelPrefabs[baseNumb];
            Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);
        }
        if (usedPosZ2 == 0)
        {
            spawnpoint = new Vector3(-0.06f, 1.58f, 17.44f);

            int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
            baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];

            GameObject baseObject = levelPrefabs[baseNumb];
            Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);
        }
        if (usedPosZ3 == 0)
        {
            spawnpoint = new Vector3(-0.06f, 1.58f, 28.5f);

            int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
            baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];

            GameObject baseObject = levelPrefabs[baseNumb];
            Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);
        }
    }
}