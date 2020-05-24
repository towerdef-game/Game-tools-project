using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    public float blastpower;
    public float bulletspeed;
    public float damage = 1f;
    public float blastraidus;
    public Transform player;
    private Vector3 target;
    private Vector3 sight;
    // Start is called before the first frame update
    public Collider[] hitcollider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        //  transform.position += (transform.forward * Time.deltaTime * bulletspeed);
        sight = (target - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //  transform.position = Vector3.MoveTowards(transform.position, target, bulletspeed * Time.deltaTime);
        transform.position +=  sight * bulletspeed * Time.deltaTime;
       //   transform.position = (transform.forward + target * Time.deltaTime * bulletspeed);
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

        if (other.gameObject.tag == "Player")
        {
            character.health--;
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
