using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject[] levelPrefabs;

    private Vector3 spawnpoint;
    public float posZ_1, posZ_2, posZ_3;
    float randomPosZ, usedPosZ1, usedPosZ2, usedPosZ3;
    float[] posNumbZ = { 6.5f, 17.44f, 28.5f };
    private int levelCurrent, randType, levelMapControl, baseAdded, baseNumb;
    int j;
    void Start()
    {
        randomPosZ = usedPosZ1 = usedPosZ2 = usedPosZ3 = 0;
        j = 3;
        int[] levelType = { 1, 2, 3, 4 };
        levelCurrent = levelType[Random.Range(0, levelType.Length)];

        int[] levelDesignRand = { 1, 2, 3 };
        randType = levelType[Random.Range(0, levelType.Length)];

        Debug.Log("levelCurrent: " + levelCurrent + " || RandType: " + randType);

        for (int i = 0; i < j; i += 1)
        {
            randomPosZ = posNumbZ[Random.Range(0, posNumbZ.Length)];

            if (randomPosZ == 28.5f) { usedPosZ3 = randomPosZ; }
            if (randomPosZ == 17.44f) { usedPosZ2 = randomPosZ; }
            if (randomPosZ == 6.5f) { usedPosZ1 = randomPosZ; }
            if (usedPosZ1 != randomPosZ)
            {
                spawnpoint = new Vector3(-0.06f, 1.58f, usedPosZ1);

                int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
                baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];
                Debug.Log("SelectedLevelBases: " + baseNumb);

                GameObject baseObject = levelPrefabs[baseNumb];
                Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);

                j++;
            }
            if (usedPosZ2 != randomPosZ)
            {
                spawnpoint = new Vector3(-0.06f, 1.58f, usedPosZ2);

                int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
                baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];
                Debug.Log("SelectedLevelBases: " + baseNumb);

                GameObject baseObject = levelPrefabs[baseNumb];
                Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);
                j++;
            }
            if (usedPosZ3 != randomPosZ)
            {
                spawnpoint = new Vector3(-0.06f, 1.58f, usedPosZ3);

                int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
                baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];
                Debug.Log("SelectedLevelBases: " + baseNumb);

                GameObject baseObject = levelPrefabs[baseNumb];
                Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);
                j++;
            }

        }
    }
}