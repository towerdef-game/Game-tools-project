using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_AI : MonoBehaviour
{
    public float Health = 2f;
    public GameObject player;
    public GameObject ammo;
    public GameObject wave;
    public NavMeshAgent brain;
    // Start is called before the first frame update
    void Start()
    {
       // wave = GameObject.Find
        brain = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        brain.destination = player.transform.position;
        if (Health <= 0)
        {
            die();
            
        }
    }
    void die()
    {
        waveSpawner.Enemiesalive--;
        Destroy(this.gameObject);
        Instantiate(ammo.transform, transform.position, transform.rotation);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            character.health--;
        }
    }
   
}
