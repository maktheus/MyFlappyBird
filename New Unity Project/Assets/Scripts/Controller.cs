using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public Pause PauseScript;

    public delegate void GameDelegate();
    public static Controller Instance;


    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;


    

    public int Score ;
    public Text scoreText;
    public static  GameObject Game;
    public GameObject GameOverPage, startPage,CountdownPage,Points;
    
    int score = 0;
    bool gameOver = false;

    enum PageState{
        None,
        Start,
        GameOver,
        Countdown,
        Points,
       
    }

    //Restart
    void Start(){

        Time.timeScale=0;
        SetPageState(PageState.Start);


    }

    public void PauseGame(){
       
       PauseScript.PauseButton();
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }


    public bool GameOver {get{return gameOver;}}

    void Awake() {
        Instance=this;    
    }

    void SetPageState(PageState state){
        switch (state)
                {

                    case PageState.None:
                        startPage.SetActive(false);
                         GameOverPage.SetActive(false);
                         CountdownPage.SetActive(false);
                         Points.SetActive(false);
                       

                    break;

                    case PageState.GameOver:
                        startPage.SetActive(false);
                         GameOverPage.SetActive(true);
                         CountdownPage.SetActive(false);
                         Points.SetActive(false);
                       
                    break;

                    case PageState.Start:
                        startPage.SetActive(true);
                         GameOverPage.SetActive(false);
                         CountdownPage.SetActive(false);
                         Points.SetActive(false);
                       
                    break;
                         
                    case PageState.Countdown:
                        startPage.SetActive(false);
                         GameOverPage.SetActive(false);
                         CountdownPage.SetActive(true);
                         Points.SetActive(false);
                       
                         
                    break;

                    case PageState.Points:
                        startPage.SetActive(false);
                         GameOverPage.SetActive(false);
                         CountdownPage.SetActive(false);
                         Points.SetActive(true);
                       
                    break;
                  
           

                }
    }


    void OnEnable() {
        CountDown.OnCountDownFinished += OnCountDownFinished;
        Bird.OnPlayerDied += OnPlayerDied;
    }

    void OnDisable() {
        CountDown.OnCountDownFinished -= OnCountDownFinished;
          Bird.OnPlayerDied -= OnPlayerDied;
    }

    void OnCountDownFinished(){
        SetPageState(PageState.None);
        OnGameStarted();
        SetPageState(PageState.Points);
        score=0;
        gameOver= true;
    }

    void OnPlayerDied(){
        gameOver = true;
        int savedScore= PlayerPrefs.GetInt("HighScore");

        if(score>savedScore){
            PlayerPrefs.SetInt("HighScore",score);
        }

        SetPageState(PageState.GameOver);

    }

    public void ConfirmGameOver(){
        //activated

        OnGameOverConfirmed();

        SetPageState(PageState.Start);

    }
    
    public void StartGame(){
        //activated
        Time.timeScale=1;
        SetPageState(PageState.Countdown);
        
        
    }
}