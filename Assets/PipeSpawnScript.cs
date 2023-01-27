using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject Pipe;
    public LogicScript logic;

    public float spawnRate = 4;
    private float timer = 0;
    public float heightOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        instantiatePipe();
        logic = GameObject.Find("LogicManager").GetComponent<LogicScript>();

    }

    void instantiatePipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(Pipe,new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint),0),transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        } else {
            if(logic.isRunning){
                instantiatePipe();
            }
            timer = 0;
        }
    }
}
