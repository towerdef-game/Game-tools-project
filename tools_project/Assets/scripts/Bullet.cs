using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed;
    private GameObject target;
    private GameObject player;
    public float damage = 1f;
  


    void Update()
    {
        transform.position += (transform.forward * Time.deltaTime * bulletspeed);
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "enemy")
        {
            target = other.gameObject;
            other.gameObject.GetComponent<enemy_AI>().Health = -damage;     
            Destroy(this.gameObject);
        }
      
        if (other.gameObject)
        {
            Destroy(this.gameObject);
        }
      
        if (bulletspeed == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
