using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Firearm : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firingPoint;
    public float projectileSpeed = 100f;
    public OVRInput.Controller controller;
    public OVRInput.Button fireButton;

    void Update()
    {
        if (OVRInput.GetDown(fireButton, controller))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("button pressed");

        GameObject projectileInstance = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        Rigidbody projectileRigidbody = projectileInstance.GetComponent<Rigidbody>();

        ParticleSystem gunParticles = firingPoint.GetComponent<ParticleSystem>();
        gunParticles.Play();

        if (projectileRigidbody != null)
        {
            projectileRigidbody.velocity = firingPoint.forward * projectileSpeed;
            Debug.Log("Bullet has been fired.");
        }
        else
        {
            Debug.LogError("Projectile does not have a Rigidbody component.");
        }
    }
}
