//This script was modified by-
//Name: Al-Hafeez
//ID: 301048593
//Date: 11/9/2019 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ScoreBoardSO",menuName ="Game/ScoreBoard")]
[System.Serializable]
public class ScoreBoardSO : ScriptableObject
{
    public int score;
    public int lives;
    public int highScore;
}
