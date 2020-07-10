using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    
    //Pipe Velocity
    void Update()
    {
      transform.position +=  Vector3.left*speed*Time.deltaTime;
    }
}
