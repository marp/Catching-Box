using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour
{
    [SerializeField] GameObject engine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        engine.GetComponent<Engine>().lifes--;
        Destroy(collision.gameObject);
    }
}
