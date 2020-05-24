using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class character : MonoBehaviour
{
    private float any;
    public float speed = 6.0F;
    public float jumpSpeed = 1.0F;
    public float gravity = 20.0F;
    public static int health ;
    public int starthealth = 5;
    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public static int ammo = 5;
    public float bullets;
    public GameObject bullet;
    public GameObject barrel;
    public bool canshoot = true;
    public float rateoffire;
    public GameManager gamemanager;
    public TextMeshProUGUI counterammo;
    public Slider Healthbar;

    void Start()
    {
        
        health = starthealth;
        controller = GetComponent<CharacterController>();
        Healthbar = GameObject.Find("Health").GetComponent<Slider>();
        counterammo = GameObject.Find("Ammo").GetComponent<TextMeshProUGUI>();
       // Healthbar = GameObject
    }
    void Update()
    {
        bullets = ammo;
        any = health;
        Healthbar.value = any;
        counterammo.text = "Ammo: " + bullets;
        if (Input.GetMouseButtonDown(0) && ammo>= 1 && canshoot == true)
        {
            shoot();
           
        }
        //CharacterController controller = GetComponent<CharacterController>();
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
            controller.enabled = false;
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
