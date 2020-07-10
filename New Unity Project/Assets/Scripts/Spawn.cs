using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject pipe;
    public float height;
    public float maxTime;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Randomize spawn 
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = transform.position + new Vector3(0,Random.Range(-height,height),0);
    }

    // Update is called once per frame
    void Update()
    {
        //spawn Time
        if(timer > maxTime){
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0,Random.Range(-height,height),0);
            Destroy(newPipe,10f);
            timer= 0f;
        }
        //timer
        timer += Time.deltaTime;
    }
}
