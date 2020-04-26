using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 
    public static int Rounds = 0;
    private bool gameEnd = false;
  //  public SceneFader SceneFader;

  //  public SceneFader sceneFader;
 
    void Start()
    {

    }
     

    // Update is called once per frame
    void Update()
    {
        if (gameEnd)
            return;
       if (character.health <= 0 )
        {
            GameOver(); 
        } 
    }

    public void GameOver()
    {
        gameEnd = true;
        SceneManager.LoadScene("Lose");
       // SceneFader.FadTo("Lose");
    }

   public void WinLevel()
    {
        
     
    }
}
