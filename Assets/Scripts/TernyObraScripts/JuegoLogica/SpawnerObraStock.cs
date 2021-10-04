using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObraStock : MonoBehaviour
{
    
    public List<GameObject> spawnPool;
    public int numberToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (waiter_not_that_waiter_just_waiter());
    }

    IEnumerator waiter_not_that_waiter_just_waiter()
    {
        for (int i = 0; i < numberToSpawn; i++) 
        {
            spawnObjectsStock();
            yield return new WaitForSeconds(1.3f);              
        }
    }

    public void spawnObjectsStock()
    {
        int randomItem = 0;
        GameObject toSpawn;
        Vector3 pos;
        float screenX, screenY, screenZ;

        randomItem = Random.Range(0, spawnPool.Count);
        toSpawn = spawnPool[randomItem];

        if (toSpawn.tag == "Verde")
        {
            screenX = -1.982607f;
            screenY = 0.1100001f;
            screenZ = -8.190461f;
            pos = new Vector3(screenX, screenY, screenZ);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        } 
        else if (toSpawn.tag == "Rojo")
        {
            screenX = -1.982607f;
            screenY = 0.1100001f;
            screenZ = -8.190461f;
            pos = new Vector3(screenX, screenY, screenZ);                
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
        else if (toSpawn.tag == "Rosa")
        {
            screenX = -1.982607f;
            screenY = 0.1100001f;
            screenZ = -8.190461f;
            pos = new Vector3(screenX, screenY, screenZ);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}
