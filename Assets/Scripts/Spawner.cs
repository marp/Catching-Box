using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] float spawnPeriod = 2f;
    [SerializeField] float velocity = 0f;
    [SerializeField] float periodAdder = 0.1f;
    Coroutine spawnCorutine;

    [SerializeField] Sprite[] sprites;

    float xMin;
    float xMax;
    void Start()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
        spawnCorutine = StartCoroutine(SpawnContinuously());
        spawnCorutine = StartCoroutine(PeriodAddEverySec());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnContinuously()
    {
        while (true)
        {
            var spawnPosX = Random.Range(xMin, xMax);
            GameObject food = Instantiate(foodPrefab, new Vector2(spawnPosX, 7f), Quaternion.identity) as GameObject;
            food.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            food.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity);
            Debug.Log(spawnPeriod);
            yield return new WaitForSeconds(spawnPeriod);
        }
    }

    IEnumerator PeriodAddEverySec()
    {
        while (true)
        {
            if (spawnPeriod > 0.5f)
            {
                spawnPeriod = spawnPeriod - spawnPeriod / 50;
            }
            else
            {
                velocity -= 0.1f;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    //IEnumerator VelocityEverySec()
    //{
    //    while (true)
    //    {

    //        yield return new WaitForSeconds(1f);
    //    }
    //}
}
