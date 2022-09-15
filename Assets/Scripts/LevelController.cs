using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject[] levelPrefabs;

    private Vector3 spawnpoint;
    public float posZ_1, posZ_2, posZ_3, randomPosZ;
    private int levelCurrent, randType, levelMapControl, baseAdded, baseNumb;

    void Start()
    {
        int[] levelType = { 1, 2, 3, 4 };
        levelCurrent = levelType[Random.Range(0, levelType.Length)];

        int[] levelDesignRand = { 1, 2, 3 };
        randType = levelType[Random.Range(0, levelType.Length)];

        Debug.Log("levelCurrent: " + levelCurrent + " || RandType: " + randType);

        float[] posNumbZ = { 6.5f, 17.44f, 28.5f };
        randomPosZ = posNumbZ[Random.Range(0, posNumbZ.Length)];
        spawnpoint = new Vector3(-0.06f, 1.58f, randomPosZ);

        int[] baseNumbs = { 0, 1, 2, 3, 4, 5 };
        baseNumb = baseNumbs[Random.Range(0, baseNumbs.Length)];
        Debug.Log("SelectedLevels: " + baseNumb);

        GameObject baseObject = levelPrefabs[baseNumb];
        Instantiate(baseObject, spawnpoint, baseObject.transform.rotation);

        for (int i = 0; i == 3; i++)
        {
            Debug.Log(i);
        }
    }
}