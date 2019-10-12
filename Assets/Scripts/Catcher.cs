using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    [SerializeField] GameObject engine;
    [SerializeField] float screenWidthInUnits = 0f;
    [SerializeField] float mouseOffset;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickSound;

    float xMin;
    float xMax;

    float yMin;
    float yMax;
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int score = Random.Range(1, 3);
        engine.GetComponent<Engine>().score += score;
        engine.GetComponent<Engine>().LiveAdderForScore += score;
        audioSource.PlayOneShot(clickSound);
        Destroy(collision.gameObject);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0.2f, 0f)).y;
    }
    private void Move()
    {
        //var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float mousePosInUnits = Input.mousePosition.x / Screen.width * (screenWidthInUnits*2)-mouseOffset;
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(paddlePos.x, -7.87f, 7.87f);
        if (!engine.GetComponent<Engine>().isPaused)
        {
            transform.position = paddlePos;
        }

        //var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        //transform.position = new Vector3(newXPos, newYPos, -9f);
    }
}
