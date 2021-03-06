﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 2nd comment

// 1st comment

namespace Functions
{

    public class Shooting : MonoBehaviour
    {
        // Stores the object we want to instanstiate
        public GameObject projectilePrefab;
        // Kickback from firing a projectile
        public float recoil = 30f;
        // Speed at which the projectile will be flung
        public float projectileSpeed = 10f;
        // Rate of fire
        public float shootRate = 0.1f;
        // Timer to count up to shootRate
        private float shootTimer = 0f;
        // Container for Rigidbody 2D
        private Rigidbody2D rigid;

        void Start()
        {
            // Get component from GameObject this script is attached to
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Increase timer
            shootTimer += Time.deltaTime;
            // IF space bar is pressed and shootTimer >= shootRate
            if (Input.GetKey(KeyCode.Space) && shootTimer >= shootRate)
            {
                // Call Shoot()
                Shoot();
                // RESET shootTimer = 0
                shootTimer = 0;
            }
        }
        void Shoot()
        {
            // Instantiate GameObject here
            GameObject projectile = Instantiate(projectilePrefab);
            // Position of projectile to Player's position
            projectile.transform.position = transform.position;
            // Get projectile's rigidbody
            Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
            projectileRigid.AddForce(transform.right * projectileSpeed);
            // Apply a recoil
            rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
        }
    }
}