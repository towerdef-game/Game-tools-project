using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed;
    public float damage = 1f;
  


    void Update()
    {
        transform.position += (transform.forward * Time.deltaTime * bulletspeed);
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "enemy")
        {       
            other.gameObject.GetComponent<enemy_AI>().Health = -damage;     
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "building")
        {
            other.gameObject.GetComponent<buildinghealth>().Health = -damage;
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
