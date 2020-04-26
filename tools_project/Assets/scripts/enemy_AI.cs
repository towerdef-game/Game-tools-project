using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_AI : MonoBehaviour
{
    public float Health = 2f;
    public GameObject player;
    public GameObject ammo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(ammo.transform, transform.position, transform.rotation);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            health.Health -= 1;
        }
    }
}
