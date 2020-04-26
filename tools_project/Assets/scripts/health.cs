using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class health : MonoBehaviour
{
    TextMeshProUGUI Timer;
    public static int Health = 5;
    // Start is called before the first frame update
    void Start()
    {
        Timer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer.text = "Health: " + Health;
            if(Health <=0)
        {
            Debug.Log("YOUR DEAD");
            SceneManager.LoadScene("Lose");
             
            SceneManager.UnloadSceneAsync("SampleScene");
           // SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);
        }
    }
   
}