using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab; //object to spawn
    [SerializeField] float spawnPeriod = 2f; //spawn period
    [SerializeField] float velocity = 0f; //velocity to bottom which makes game harder
    [SerializeField] float periodAdder = 0.1f; //add more fruits every sec

    [SerializeField] Sprite[] sprites; //diffrent sprites for foods

    float xMin; //min pos to spawn
    float xMax; //max pos to spawn
    void Start()
    {
        Camera gameCamera = Camera.main; //assign main camera to var
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
        StartCoroutine(SpawnContinuously());
        StartCoroutine(PeriodAddEverySec());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnContinuously()
    {
        while (true) //make spawning endless
        {
            var spawnPosX = Random.Range(xMin, xMax); //pos to spawn randomized beetwen limits
            GameObject food = Instantiate(foodPrefab, new Vector2(spawnPosX, 7f), Quaternion.identity); //spawning food object
            food.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)]; //chang sprite to random from array
            food.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity); //add velocity
            yield return new WaitForSeconds(spawnPeriod); //wait until new spawn
        }
    }

    IEnumerator PeriodAddEverySec()
    {
        while (true) //endless loop
        {
            if (spawnPeriod > 0.5f) //if period is greater than 0.5 subtract period
            {
                spawnPeriod = spawnPeriod - spawnPeriod / 50; //alghoritm for decreasing period
            }
            else //if not add velocity
            {
                velocity -= 0.1f; //adds negative velocity
            }
            yield return new WaitForSeconds(1f); //do it every 1 sec
        }
    }
}
