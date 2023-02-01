using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public LogicScript logic;

    private Vector2 screenBounds;

    public float flapStrength = 20;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,Camera.main.orthographicSize);
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

        if(transform.position.y > screenBounds.y | transform.position.y < -screenBounds.y){
            logic.gameOver();
        }

    }
    private void OnCollisionEnter2D(Collision2D other) {
        logic.gameOver();
    }
}
