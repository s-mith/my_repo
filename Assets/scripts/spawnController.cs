using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    // spawnpoint
    public GameObject spawnPoint;

    public GameObject camera_area;

    public int max_wait = 40;

    public float decrease_waittime = 0.0f;

    // every 1-max_wait seconds, spawn an enemy

    // Start is called before the first frame update
    void Start()
    {
        decrease_waittime = Time.time;
        StartCoroutine(SpawnEnemy());

    }

    // Update is called once per frame
    void Update()
    {

        
    }


    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // wait for a random amount of time
            // for every 15 seconds that have passed, decrease the max_wait time by 1
            float decreaser = (Time.time - decrease_waittime)/15;
            // make decreaser an int
            int decreaser_int = (int)decreaser;

            yield return new WaitForSeconds(Random.Range(1, max_wait - decreaser_int));

            // spawn an enemy
            // check if spawnpoint is in camera area
            if (!(spawnPoint.transform.position.x < camera_area.transform.position.x + camera_area.transform.localScale.x/2 && spawnPoint.transform.position.x > camera_area.transform.position.x - camera_area.transform.localScale.x/2))
            {
                if (!(spawnPoint.transform.position.y < camera_area.transform.position.y + camera_area.transform.localScale.y/2 && spawnPoint.transform.position.y > camera_area.transform.position.y - camera_area.transform.localScale.y/2))
                {
                    // spawn an enemy
                    
            int enemyType = Random.Range(1, 4);
            if (enemyType == 1)
            {
                // instantiate the enemy at z 0
                Instantiate(enemy1, spawnPoint.transform.position, Quaternion.identity);

                // Instantiate(enemy1, spawnPoint.transform.position, Quaternion.identity);
            }
            else if (enemyType == 2)
            {
                Instantiate(enemy2, spawnPoint.transform.position, Quaternion.identity);
            }
            else if (enemyType == 3)
            {
                Instantiate(enemy3, spawnPoint.transform.position, Quaternion.identity);
            }
        }}
        }
    }
}
