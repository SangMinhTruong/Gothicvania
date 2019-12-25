﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public static Shoot instance;
    public float fireRate = 1;
   // public int damage = 10;
    public LayerMask WhatToHit;
    float FireTime = 0;
    private GameObject jt;
    //public Joystick joystick;
    public float EffectSpawnRate = 1;
    float effectSpawnTime = 0;
    private bool isCrouching=false;
    Transform GunPooint;
    public Transform BulletPrefab;
    public Transform BulletLeftPrefab;
    private Vector2 Direction;
    private PlayerController playerController;

    //[SerializeField]
   
    void Start()
    {
        playerController = PlayerController.instance;
    }
    // Start is called before the first frame update
    void Awake()
    {
        jt = GameObject.FindGameObjectWithTag("JoyStick");
        if(instance==null)
        {
            instance = this;
        }
        if(jt!=null)
        {
            //joystick = Joystick.FindObjectOfType(Joystick);
            variableJoystick = jt.GetComponent<VariableJoystick>();
        }
        GunPooint = transform.Find("Gunpoint");
        if (GunPooint == null)
        {
            Debug.LogError("NaNI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // else { GunPooint = transform.Find("Gunpoint"); }
        Debug.Log("attack?" + PlayerController.isAttacking.ToString());
        if (variableJoystick.Vertical<=-0.4f)//Input.GetButtonDown("Crouch"))
        {
            
            //Debug.LogError("Why wont you change");
            // Direction = new Vector2(transform.position.x, transform.position.y);
            isCrouching = true;
            Debug.Log("Sited"+isCrouching);
            GunPooint = transform.Find("gunCrouchPoint");
        }
        else //(joystick.Vertical>=-0.4f)
        {
            isCrouching = false;
            //Direction = new Vector2(transform.position.x, transform.position.y + 0.085f);
            GunPooint = transform.Find("Gunpoint");
        }
        //if (Input.GetButtonDown("Crouch"))
        //{
        //    isCrouching = true;
        //    GunPooint = transform.Find("gunCrouchPoint");
            
        //}
        //if(Input.GetButtonUp("Crouch"))
        //{
        //    isCrouching = false;
        //    GunPooint = transform.Find("Gunpoint");
            
        //}
        if(isCrouching)
        {
            if (fireRate == 0)
            {
                if (PlayerController.isAttacking)//Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("Got 'em");
                    CrouchShooot(isCrouching);
                }
            }
            else
            {
                if (PlayerController.isAttacking && Time.time > FireTime)
                {
                    FireTime = Time.time + (1 / fireRate);
                    CrouchShooot(isCrouching);
                }
            }
        }
        else
        {
            if (fireRate == 0)
            {
                if (PlayerController.isAttacking)
                {
                    Shooot(isCrouching);
                }
            }
            else
            {
                if (PlayerController.isAttacking && Time.time > FireTime)
                {
                    FireTime = Time.time + (1 / fireRate);
                    Shooot(isCrouching);
                }
            }
        }
    }
    void Shooot(bool crouch)
    {
        //Debug.Log("Not crouch shooting");
       // Vector2 mouspoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 PorjStart = new Vector2(GunPooint.position.x, GunPooint.position.y);
        Direction = new Vector2(transform.position.x, transform.position.y + 0.098f);
        //if (Input.GetButtonDown("Crouch"))
        //{
        //    //Debug.LogError("Why wont you change");
        //     Direction = new Vector2(transform.position.x, transform.position.y);
        //   //Direction= new Vector2()
        //}
        //// else { GunPooint = transform.Find("Gunpoint"); }
        ////if (Input.GetButtonUp("Crouch"))
        ////{

        ////    //GunPooint = transform.Find("Gunpoint");
        ////}
        ///
        Vector2 crouchDirection = new Vector2(transform.position.x, transform.position.y - 0.025f);
        Vector2 Dir;
        if (crouch)
        {
            Dir = crouchDirection;
        }
        else
            Dir = Direction;
        RaycastHit2D hit = Physics2D.Raycast(PorjStart, PorjStart - Direction, 100, WhatToHit);
        if (Time.time >= effectSpawnTime)
        {
            Vector3 hitpos;
            if (hit.collider == null)
            {
                hitpos = (GunPooint.position - transform.position) * 30;
            }
            else
                hitpos = hit.point;
            Effect(hitpos);
            effectSpawnTime = Time.time + 1 / EffectSpawnRate;
        }

        //if (hit.collider != null)
        //{
        //    Enemy enemy = hit.collider.GetComponent<Enemy>();
        //    if(enemy!= null)
        //    {
        //        enemy.DamageEnemy(damage);
        //    }
        //    Debug.DrawLine(PorjStart, hit.point, Color.red);
        //   // Debug.Log("We hit " + hit.collider.name + "and did " + damage + "Damage");
        //}

        //Debug.Log("Oh no");
        Debug.DrawLine(PorjStart,Direction,Color.red,200,false);
    }

    void CrouchShooot(bool crouch)
    {
        Debug.Log("Not crouch shooting");
        // Vector2 mouspoint = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 PorjStar = new Vector2(GunPooint.position.x, GunPooint.position.y);
        Vector2 Direct = new Vector2(transform.position.x, transform.position.y );
        //if (Input.GetButtonDown("Crouch"))
        //{
        //    //Debug.LogError("Why wont you change");
        //     Direction = new Vector2(transform.position.x, transform.position.y);
        //   //Direction= new Vector2()
        //}
        //// else { GunPooint = transform.Find("Gunpoint"); }
        ////if (Input.GetButtonUp("Crouch"))
        ////{

        ////    //GunPooint = transform.Find("Gunpoint");
        ////}
        ///
        //Vector2 crouchDirection = new Vector2(transform.position.x, transform.position.y - 0.025f);
        //Vector2 Dir;
        //if (crouch)
        //{
        //    Dir = crouchDirection;
        //}
        //else
        //    Dir = Direction;
        RaycastHit2D hit2 = Physics2D.Raycast(PorjStar, PorjStar - Direct, 100, WhatToHit);
        if (Time.time >= effectSpawnTime)
        {
            Vector3 hitpos;
            if (hit2.collider == null)
            {
                hitpos = (GunPooint.position - transform.position) * 30;
            }
            else
                hitpos = hit2.point;
            Effect(hitpos);
            effectSpawnTime = Time.time + 1 / EffectSpawnRate;
        }

        //if (hit2.collider != null)
        //{
        //    Enemy enemy = hit2.collider.GetComponent<Enemy>();
        //    if (enemy != null)
        //    {
        //        enemy.DamageEnemy(damage);
        //    }
        //    Debug.DrawLine(PorjStar, hit2.point, Color.red);
        //   // Debug.Log("We hit " + hit2.collider.name + "and did " + damage + "Damage");
        //}

        //Debug.Log("Oh no");
        Debug.DrawLine(PorjStar, Direct, Color.red, 200, false);
    }
    void Effect(Vector3 hitpos)
    {
        if (this.transform.localScale.x > 0)
        {
            Transform trail=Instantiate(BulletPrefab, GunPooint.position, GunPooint.rotation);


        }
        else
        {
            Instantiate(BulletLeftPrefab, GunPooint.position, GunPooint.rotation);
        }

    }
}


