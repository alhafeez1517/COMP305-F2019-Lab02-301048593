//This script was modified by-
//Name: Al-Hafeez
//ID: 301048593
//Date: 11/9/2019 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SceneSettings",menuName ="Scene/Settings")]
[System.Serializable]
public class SceneSettings : ScriptableObject
{
    [Header("Scene Configuration")]
    public SceneOrder sceneOrder;
    public SoundClip activeSoundClip;

    [Header("Scoreboard Configuration")]
    public bool scoreLabelEnabled;
    public bool livesLabelEnabled;
  

    [Header("Scene Labels")]
    public bool startLabelActive;
    public bool highScoreLabelEnabled;
    public bool endLabelActive;

    [Header("Scene Buttons")]
    public bool startButtonActive;
    public bool restartButtonActive;



}
