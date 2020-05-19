using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed;
    public float damage = 1f;
    public float blastraidus;
    public float blastpower;
 
    public Collider[] hitcollider;


    void Update()
    {
        transform.position += (transform.forward * Time.deltaTime * bulletspeed);
    }
    void explsion()
    {
        Vector3 explosionpos = transform.position;
        hitcollider = Physics.OverlapSphere(explosionpos, blastraidus);

        foreach (Collider hit in hitcollider)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(blastpower, explosionpos, blastraidus, 3.0f);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        explsion();

        if (other.gameObject.tag == "enemy")
        {       
          //  other.gameObject.GetComponent<Rigidbody>
            other.gameObject.GetComponent<enemy_AI>().Health = -damage;     
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "building")
        {
            other.gameObject.GetComponent<buildinghealth>().Health = -damage;
            Destroy(this.gameObject);
          //  explsion();
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
