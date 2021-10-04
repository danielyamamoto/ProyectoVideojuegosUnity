using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObra : MonoBehaviour
{
    
    public List<GameObject> spawnPool;
    public int numberToSpawn;
    //public int numPedidos;
    //public int numRojos;
    //public int numRosas;
    //public GameObject[] spawnList;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (waiter_not_that_waiter_just_waiter());
    }

    IEnumerator waiter_not_that_waiter_just_waiter()
    {
        for (int i = 0; i < numberToSpawn; i++) 
        {
            spawnObjectsBloqueo();
            yield return new WaitForSeconds(1.3f);              
        }
    }

    public void spawnObjectsBloqueo()
    {
        int randomItem = 0;
        GameObject toSpawn;
        Vector3 pos;
        float screenX, screenY, screenZ;

        randomItem = Random.Range(0, spawnPool.Count);
        toSpawn = spawnPool[randomItem];

        if (toSpawn.tag == "Pedido")
        {
            //numPedidos++;
            screenX = 2.702f;
            screenY = .2080582f;
            screenZ = -10.146f;
            pos = new Vector3(screenX, screenY, screenZ);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        } 
        else if (toSpawn.tag == "Rojo")
        {
            //numRojos++;
            screenX = 2.762f;
            screenY = 0.274f;
            screenZ = -10.15f;
            pos = new Vector3(screenX, screenY, screenZ);                
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
        else if (toSpawn.tag == "Rosa")
        {
            //numRosas++;
            screenX = 2.762f;
            screenY = 0.274f;
            screenZ = -10.15f;
            pos = new Vector3(screenX, screenY, screenZ);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}
