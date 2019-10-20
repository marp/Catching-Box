using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject engine;
    [SerializeField] TextMeshProUGUI TimerTextGO;
    [SerializeField] TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = engine.GetComponent<Engine>().score.ToString(); //shows score count on game over screen
        TimerTextGO.text = TimerText.text; //shows time on game over screen
    }
}
