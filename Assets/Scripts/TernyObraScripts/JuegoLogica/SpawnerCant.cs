using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCant : MonoBehaviour
{
    public GameObject toSpawn;
    public int spawnNum;

    void Start()
    {
        StartCoroutine (waiter_not_that_waiter_just_waiter());
    }

    IEnumerator waiter_not_that_waiter_just_waiter()
    {
        Vector3 pos;
        float screenX, screenY, screenZ;
        screenX = -9.12f;
        screenY = 0.475f;
        screenZ = -4.32f;
        pos = new Vector3(screenX, screenY, screenZ);

        for (int i = 0; i < spawnNum; i++) 
        {
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

            yield return new WaitForSeconds(2f);              
        }
    }
}
