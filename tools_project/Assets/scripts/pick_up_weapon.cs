using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up_weapon : MonoBehaviour
{

    Vector3 objectPos;
    float distance;

    //public bool canHold = true;
    // public GameObject item;
    public GameObject hands;
    public bool holding = false;
    public bool onfire = true;
    private ParticleSystem myfire;
    //public AudioSource Burning;

    void Start()
    {
  
        hands = GameObject.Find("hands");
   
        //  Burning = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(this.transform.position, hands.transform.position);
        if (distance >= 1f)
        {
            holding = false;
        }
      

        if (Input.GetKeyDown(KeyCode.E) && holding == false && onfire == false)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5))
            {
                hold();
            }
        }
        if (Input.GetKey(KeyCode.Q) && holding == true)
        {
            drop();
        }

        //check if holding
        if (holding == true)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.transform.SetParent(hands.transform);

            if (Input.GetKeyDown(KeyCode.F))
            {
                // throw
            }
        }
        else
        {
            objectPos = this.transform.position;
            this.transform.SetParent(null);
            this.GetComponent<Rigidbody>().useGravity = true;
            this.transform.position = objectPos;
        }
      
    }
    void hold()
    {
        holding = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().detectCollisions = true;
    }
  
    void drop()
    {
        holding = false;
    }
}
