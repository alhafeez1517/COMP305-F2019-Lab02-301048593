//This script was modified by-
//Name: Al-Hafeez
//ID: 301048593
//Date: 11/9/2019 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;
    public int numberOfClouds;
    public List<GameObject> clouds;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard Data")]
    [SerializeField]
    private int _lives;
    [SerializeField]
    private int _score;

    [Header("Scoreboard UI")]
    public Text livesLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    [Header("Game Settings")]
    public ScoreBoardSO scoreBoard;

    [Header("Scene Settings")]
    public List<SceneSettings> sceneSettings;
    private SceneSettings activeSceneSettings;

    [Header("UI Control")]
    private GameObject startLabel;
    private GameObject startButton;
    private GameObject endLabel;
    private GameObject restartButton;

 
    // public properties
    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            scoreBoard.lives = _lives;
            if (_lives < 1)
            {
                
                SceneManager.LoadScene("End");
            }
            else
            {
                livesLabel.text = "Lives: " + scoreBoard.lives;
            }
           
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            scoreBoard.score = _score;




            if (scoreBoard.highScore<_score)
            {
                scoreBoard.highScore = _score;
                
            }
            scoreLabel.text = "Score: " + scoreBoard.score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObjectInitialization();
        SceneConfiguration();
        
    }

    private void GameObjectInitialization()
    {
   
        startLabel = GameObject.Find("StartLabel");
        endLabel = GameObject.Find("EndLabel");
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");

        //This is to find the ScoreBoardSO object in the Assets folder(not anymore)

        //scoreBoard = Resources.FindObjectsOfTypeAll<ScoreBoardSO>()[0] as ScoreBoardSO;
       // sceneSettings = Resources.FindObjectsOfTypeAll<SceneSettings>().ToList();
     
    }


    private void SceneConfiguration()
    {
       

       var sceneQuery=from settings in sceneSettings
                                 where settings.sceneOrder == (SceneOrder)Enum.Parse(typeof(SceneOrder), 
                                 SceneManager.GetActiveScene().name.ToUpper())
                                 select settings;

 activeSceneSettings = sceneQuery.ToList()[0];
   

        {
            scoreLabel.enabled = activeSceneSettings.scoreLabelEnabled;
            livesLabel.enabled = activeSceneSettings.livesLabelEnabled;
            highScoreLabel.enabled = activeSceneSettings.highScoreLabelEnabled;
            startLabel.SetActive(activeSceneSettings.startLabelActive);
            endLabel.SetActive(activeSceneSettings.endLabelActive);
            startButton.SetActive(activeSceneSettings.startButtonActive);
            restartButton.SetActive(activeSceneSettings.restartButtonActive);
            activeSoundClip = activeSceneSettings.activeSoundClip;
            highScoreLabel.text = "High Score: " + scoreBoard.highScore;
            scoreLabel.text = "Score: " + scoreBoard.score;
            livesLabel.text = "Lives: " + scoreBoard.lives;

        }

        if (activeSceneSettings.sceneOrder == SceneOrder.MAIN)
        {
            Lives = 5;
            Score = 0;
        }
       
     


        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }



        // creates an empty container (list) of type GameObject
        clouds = new List<GameObject>();

        for (int cloudNum = 0; cloudNum < numberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        Instantiate(island);
    }

    // Event Handlers
    public void OnStartButtonClick()
    {
      
        SceneManager.LoadScene("Main");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
