using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "QuizData", order = 1)]
public class QuizData : ScriptableObject
{
    public string question;
    public Sprite[] answer;
}
