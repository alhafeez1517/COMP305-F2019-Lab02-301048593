using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ScoreBoardSO",menuName ="Game/ScoreBoard")]
[System.Serializable]
public class ScoreBaordSO : ScriptableObject
{
    public int score;
    public int lives;
    public int highScore;
}
