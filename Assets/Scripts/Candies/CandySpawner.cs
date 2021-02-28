using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxPosX = 6.7f;

    public GameObject[] Candies;

    public static CandySpawner instance;

    public float spawnInterval = 1f;
    

    private void Awake()
    {
        if (instance == null)

        {
            instance = this;
        }
    }

    void Start()
    {
        //  SpawnCandy ();

        StartSpawningCandies();

    }


    void SpawnCandy()
    {
        int randomSpawn = Random.Range(0, Candies.Length);

        float randomX = Random.Range(-maxPosX, maxPosX);
        Vector3 randomPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(Candies[randomSpawn], randomPosition, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }



}
