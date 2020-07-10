using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontos : MonoBehaviour
{
    
    public Controller controller;
    
    void Start() {
        controller = FindObjectOfType<Controller>();
    }

     void OnTriggerEnter2D(Collider2D colisor) {
        Sounds.PlaySound("point");
        
      controller.Score++;
      controller.scoreText.text = controller.Score.ToString();

  }
}
