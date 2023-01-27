using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public LogicScript logic;

    public float flapStrength = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3.5f;
        logic = GameObject.Find("LogicManager").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && logic.isRunning){
            rb.velocity = Vector2.up * flapStrength;
        }
        if (!logic.isRunning){
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        logic.gameOver();
    }
}
