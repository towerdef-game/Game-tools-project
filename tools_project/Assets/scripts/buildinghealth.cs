using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildinghealth : MonoBehaviour
{
    public float Health = 2f;
    void Update()
    {
      //  brain.destination = player.transform.position;
        if (Health <= 0)
        {
            die();

        }
    }
    void die()
    {
        Destroy(this.gameObject);
     //   Instantiate(ammo.transform, transform.position, transform.rotation);
     
    }

}
