﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class DiscMoveStandard : MonoBehaviour
{

    public float discSpeedX = 5f;
    public float discSpeedY = 5f;
    public float rayDist = 1f;

    public Rigidbody2D thisRigidbody2d;
    public LayerMask wallMask;

    public GameObject self;

    public float freezeTimer;
    public float bounceTimer;

    void Start()
    {
        freezeTimer = 500f;
        bounceTimer = 0f;

        discSpeedX = 0f;
        discSpeedY = 0f;
    }

    void Update()
    {
        //Stay frozen until freezeTimer hits 0

        if (freezeTimer > 0)
        {
            Renderer r = self.GetComponent<Renderer>();
            Color selfAlpha = r.material.color;

            selfAlpha.a = 0.5f;

            discSpeedX = 0;
            discSpeedY = 0;
            freezeTimer--;
        }

        else
        {
            discSpeedX = 5f;
            discSpeedY = 5f;
        }

        //Create rays pointing to the top, bottom, left, and right sides of the object
        //If the top or bottom rays collide with a wall, flip the y speed
        //If the right or left rays collide with a wall, flip the x speed

        if (bounceTimer < 0f)
        {

        if (Physics2D.Raycast(rightRay.origin, rightRay.direction, rayDist))
        {
            
            if (hitRight.collider != null)
            {
                discSpeedX *= -1;
                bounceTimer = 10f;
            }
            
        }

            Ray leftRay = new Ray(transform.position, Vector2.left);
            Debug.DrawRay(leftRay.origin, leftRay.direction, Color.white);
            RaycastHit2D hitLeft = Physics2D.Raycast(leftRay.origin, leftRay.direction, rayDist, wallMask);

        if (Physics2D.Raycast(leftRay.origin, leftRay.direction, rayDist))
        {

            
            if (hitLeft.collider != null)
            {
                discSpeedX *= -1;
                bounceTimer = 10f;
            }
            
        }

            Ray topRay = new Ray(transform.position, Vector2.up);
            Debug.DrawRay(topRay.origin, topRay.direction, Color.white);
            RaycastHit2D hitTop = Physics2D.Raycast(topRay.origin, topRay.direction, rayDist, wallMask);

        if (Physics2D.Raycast(topRay.origin, topRay.direction, rayDist))
        {

            
            if (hitTop.collider != null)
            {
                discSpeedY *= -1;
                bounceTimer = 10f;
            }

            
        }

            Ray bottomRay = new Ray(transform.position, Vector2.down);
            Debug.DrawRay(bottomRay.origin, bottomRay.direction, Color.white);
            RaycastHit2D hitBottom = Physics2D.Raycast(bottomRay.origin, bottomRay.direction, rayDist, wallMask);

        if (Physics2D.Raycast(bottomRay.origin, bottomRay.direction, rayDist))
        {
            
            if (hitBottom.collider != null)
            {
                discSpeedY *= -1;
                bounceTimer = 10f;
            }
            
        }


        //Always be moving on the X and Y axis
        thisRigidbody2d.velocity = new Vector3(discSpeedX, discSpeedY);
    }

    void FixedUpdate()
    {

    }
}
