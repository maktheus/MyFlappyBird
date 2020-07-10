using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;
    public GameObject GameOver;
    public float scrollSpeed;
    private Rigidbody2D rig;
   private bool live=true;

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
  
    
    Quaternion downRotation, upRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        live=true;
         GameOver.SetActive(false);
        rig= GetComponent<Rigidbody2D>();   

        //Bird fall

        downRotation = Quaternion.Euler(0,0,-40);
        upRotation = Quaternion.Euler(0,0,45);
        

    }

    // Update is called once per frame
    void Update()
    {
        //Click button
         if(live){
            if(Input.GetMouseButtonDown(0)){
                Sounds.PlaySound("jump");
                transform.rotation = upRotation;
                rig.velocity = Vector2.up*speed;
                
            }
         }

       
        transform.rotation = Quaternion.Lerp(transform.rotation,downRotation,2*Time.deltaTime);

        //Bird forward moviment
        
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;
        
      
    }


    void OnEnable() {
         Controller.OnGameStarted +=OnGameStarted;
         Controller.OnGameOverConfirmed +=OnGameOverConfirmed;
    }

    void OnDisable() {
        Controller.OnGameStarted -=OnGameStarted;
         Controller.OnGameOverConfirmed -=OnGameOverConfirmed;
    }

    void OnGameStarted(){
        rig.velocity= Vector3.zero;
        rig.simulated= true;

    }

      void OnGameOverConfirmed(){
    
       transform.rotation = Quaternion.identity;

    }


    //Colision 

    private void OnCollisionEnter2D(Collision2D colisor) {
        Sounds.PlaySound("hit");
        Sounds.PlaySound("die");
        rig.simulated=false;
        Time.timeScale=0;
        live=false;
        OnPlayerDied();// Controller

        
   }
}
