using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public int amount;
    float spawnInterval = 2f;
    float minimumSpawnInterval = 1f;
    float intervalDecrease = 0.25f;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        amount = 0;
    }


    IEnumerator SpawnEnemies()
    {

        while (true)
        {
            if (objectToSpawn != null && spawnPoint != null && amount <=1)
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                amount = amount+1;
                Debug.Log(amount);
            }
            else 
            {
                Debug.LogWarning("Object to spawn or the spawn point is not set");
            }
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - intervalDecrease);
        } 
    }
}
