using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manaer : MonoBehaviour
{
    public GameObject settings;
    public GameObject startscreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }
  public  void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void reload()
    {
        SceneManager.LoadScene("Level 1");
        character.ammo = 5;
        waveSpawner.Enemiesalive = 0;
    }
    public void Settings()
    {
        settings.SetActive(true);
        startscreen.SetActive(false);
    }
    public void back()
    {
        settings.SetActive(false);
        startscreen.SetActive(true);
    }
   public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
  
}
