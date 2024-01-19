using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverUI; //L'objet est l'UI
    void EndGame ()
    {
        Debug.Log("GAME OVER");
    }

    public void gameOver() //Active l'UI quand GameOver
    {
        gameOverUI.SetActive(true);
    }
}
