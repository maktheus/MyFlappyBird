using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   
   public static  bool GamePaused = false;
    public GameObject PauseMenu;
    
    
    public void PauseButton(){
        if(GamePaused){
            Resume();
        }else
        {
            PauseGame();
        }
    }

    public void Resume(){
        PauseMenu.SetActive(false);
         Time.timeScale=1f;
         GamePaused=false;
    }

    public void PauseGame(){
        PauseMenu.SetActive(true);
         Time.timeScale=0f;
         GamePaused=true;
    }
   
}
