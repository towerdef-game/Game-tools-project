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
    public float shootingdistance;
   // public bool canshoot;
    public GameObject eye;
    public GameObject bullet;
    private float timebtwnshots;
    public float starttimebtwnshots;
    // Start is called before the first frame update
    void Start()
    {
       // wave = GameObject.Find
        brain = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        timebtwnshots = starttimebtwnshots;
    }

    // Update is called once per frame
    void Update()
    {
        float distancetoenemy = Vector3.Distance(transform.position, player.transform.position);
        if(distancetoenemy < shootingdistance)
        {
            timebtwnshots -= Time.deltaTime;
            if(timebtwnshots <= 0)
            {
                shoot();
            }
          //  shoot();
        }
        if(distancetoenemy > shootingdistance)
        {
            timebtwnshots = starttimebtwnshots;
        }
     
        
        
        
        brain.destination = player.transform.position;
        if (Health <= 0)
        {
            die();
            
        }
    }
    void shoot()
    {
        Instantiate(bullet, eye.transform.position, transform.rotation);
        timebtwnshots = starttimebtwnshots;
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
        if(other.gameObject.tag == "building")
        {
            die();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingdistance);

    }
}
