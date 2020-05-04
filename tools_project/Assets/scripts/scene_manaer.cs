using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manaer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
  public  void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
   public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
  
}
