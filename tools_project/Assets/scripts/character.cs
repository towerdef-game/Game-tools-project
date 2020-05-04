using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class character : MonoBehaviour
{
    
    public float speed = 6.0F;
    public float jumpSpeed = 1.0F;
    public float gravity = 20.0F;
    public static int health = 5;
    
    private Vector3 moveDirection = Vector3.zero;
    public static int ammo = 5;
    public GameObject bullet;
    public GameObject barrel;
    public bool canshoot = true;
    public float rateoffire;
    public GameManager gamemanager;
    TextMeshProUGUI heal;

    void Start()
    {
        
        heal = GameObject.Find("Health"). GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
      
        heal.text = health.ToString("Health:"+ health);
        if (Input.GetMouseButtonDown(0) && ammo>= 1 && canshoot == true)
        {
            shoot();
           
        }
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
       
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        //}
       }
        if (health <= 0)
        {
            Debug.Log("YOUR DEAD");
           // gamemanager.WinLevel();
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
    void shoot()
    {
        Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        ammo -= 1;
        canshoot = false;

        StartCoroutine(FireRate());
    }
    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(rateoffire);
        canshoot = true;
    }
}
