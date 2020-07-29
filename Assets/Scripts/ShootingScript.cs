using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject hole;
    public GameObject bullet;
    public GameObject effect;

    public ProjectileData projectileData;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!effect.active)
        {
            effect.SetActive(true);
            RotateHoleToDirection(Input.mousePosition);
            GameObject bull                       = Instantiate(bullet, hole.transform);
            bull.GetComponent<Projectile>().force = projectileData.force;
            bull.transform.parent                 = null;
            bull.SetActive(true);
        }
        else
        {
            print("Whhhaaaaiiit Dude, Reload,Can you see it?");
        }
    }

    void RotateHoleToDirection(Vector3 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Physics.Raycast(ray, out RaycastHit hit);
        if (hit.collider)
        {
            hole.transform.LookAt(hit.point);
        }
    }
}
