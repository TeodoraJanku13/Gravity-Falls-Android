using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

        
        float maxPosX = 6.7f;

        public float spawnInterval = 3;

        public GameObject[] Powerups;

        public static PowerupSpawner instance;


        private void Awake()
        {
            if (instance == null)

            {
                instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        StartSpawningPowerups();
        //StartCoroutine(SpawnPowerups());
        }


        void SpawnPowerup()
        {
            int randomSpawn = Random.Range(0, Powerups.Length);

            float randomX = Random.Range(-maxPosX, maxPosX);

            Vector3 randomPosition = new Vector3(randomX, transform.position.y, transform.position.z);

          var down = Instantiate(Powerups[randomSpawn], randomPosition, transform.rotation);

          // down.GetComponent <Rigidbody> ().AddForce(Vector2.down * force);
        }


        IEnumerator SpawnPowerups()
        {
            while (true)
            {
                yield return new WaitForSeconds(20f);

                SpawnPowerup();
            }
        }

      public void StartSpawningPowerups()
        {
            StartCoroutine("SpawnPowerups");
        }

        public void StopSpawningPowerups()
        {
            StopCoroutine("SpawnPowerups");
        }          
   }