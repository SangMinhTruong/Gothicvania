using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPoint;
    public Transform crouchGunPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")
         && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerShoot")
         && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouchShoot")
         && !gameObject.GetComponent<PlayerController>().IsJumping)
            Shoot();
    }
    void Shoot()
    {
        if (!gameObject.GetComponent<PlayerController>().IsCrouching)
        {
            Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
            gameObject.GetComponent<Animator>().Play("PlayerShoot");
        }
        else
        {
            Instantiate(bulletPrefab, crouchGunPoint.position, crouchGunPoint.rotation);
            gameObject.GetComponent<Animator>().Play("PlayerCrouchShoot");

        }

    }
}


