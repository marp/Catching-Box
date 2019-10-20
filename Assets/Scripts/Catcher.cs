using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    [SerializeField] GameObject engine;
    [SerializeField] float screenWidthInUnits = 0f;
    [SerializeField] float mouseOffset; //offset for calibrating mouse with screen
    [SerializeField] float padding = 1f; //padding for catcher


    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip catchSound;


    //max and min for x and y on screen
    float xMin;
    float xMax;

    float yMin;
    float yMax;

    void Start()
    {
        SetUpMoveBoundaries(); //set limit for catcher
    }

    void Update()
    {
        Move(); //makes move every frame
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int score = Random.Range(1, 3); //randomize score points
        engine.GetComponent<Engine>().score += score; //adds score
        engine.GetComponent<Engine>().LiveAdderForScore += score; //adds score to life adder score
        audioSource.PlayOneShot(catchSound); //play sfx after catch
        Destroy(collision.gameObject); //remove the fruit object
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main; //assign main camera to variable
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0.2f, 0f)).y;
    }
    private void Move()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * (screenWidthInUnits*2)-mouseOffset; //convert mouse pos to unity units
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y); //makes vector2 with x position dependendt from mouse
        paddlePos.x = Mathf.Clamp(paddlePos.x, -7.87f, 7.87f); //make limit for paddle pos
        if (!engine.GetComponent<Engine>().isPaused) //if false makes catcher stay in place
        {
            transform.position = paddlePos; //set catcher pos
        }
    }
}
