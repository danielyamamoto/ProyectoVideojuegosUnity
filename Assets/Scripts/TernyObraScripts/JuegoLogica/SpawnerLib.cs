using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLib : MonoBehaviour
{
    public GameObject objToSpawn;
    public int numToSpawn;

    void Start()
    {
        StartCoroutine (waiter_not_that_waiter_just_waiter());
    }

    IEnumerator waiter_not_that_waiter_just_waiter()
    {
        for (int i = 0; i < numToSpawn; i++) 
        {
            spawnObjects();
            yield return new WaitForSeconds(2.5f);              
        }
    }

    void spawnObjects()
    {
        Vector3 pos;
        float screenX, screenY, screenZ;

        screenX = 7.31f;
        screenY = .681f;
        screenZ = -3.936f;
        pos = new Vector3(screenX, screenY, screenZ);
        Instantiate(objToSpawn, pos, objToSpawn.transform.rotation);
    }
}
