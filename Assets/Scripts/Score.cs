using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Score_text; 
    int score = 0;
    public static Score instance;

    private void Awake()
    {
        instance = this;
    }

    public void Add_score() //"Score: " est le text + score est la valeur
    {
        score += 1;
        Score_text.text = "Score: " + score;
    }


}
