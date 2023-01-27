using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -45){
            Destroy(gameObject);
        }
        if (logic.isRunning){
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        }
    }
   
}
