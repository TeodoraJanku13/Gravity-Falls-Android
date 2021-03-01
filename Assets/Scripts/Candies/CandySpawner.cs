using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CandySpawner : MonoBehaviour
{

    public GameObject[] Candies;

    public static CandySpawner instance;

    public float timeDelay;

    int currentLevel;


    private void Awake()
    {
        if (instance == null)

        {
            instance = this;
        }
    }

    void Start()
    {
        StartSpawningCandies();
        
        timeDelay = 1f;
        
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel ==6 || currentLevel == 7 || currentLevel == 8)
        {
        StartCoroutine("IncreaseSpawnSpeed");
        }

    }

    private void Update()
    {
       
    }


 
    IEnumerator SpawnCandies()
    {
       yield return new WaitForSeconds(2f);

        while (true)
        {
            int randomSpawn = Random.Range(0, Candies.Length);

            float randomX = Random.Range(-6.7f, 6.7f);

            Vector3 randomPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            Instantiate(Candies[randomSpawn], randomPosition, transform.rotation);     

            yield return new WaitForSeconds(timeDelay);


        }
    }

    public IEnumerator IncreaseSpawnSpeed()
    {
        while (true)
        {
        yield return new WaitForSeconds(10);
        timeDelay -= 0.05f;
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
