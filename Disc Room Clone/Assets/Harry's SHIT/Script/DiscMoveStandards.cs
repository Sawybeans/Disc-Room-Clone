using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class DiscMoveStandards : MonoBehaviour
{

    public float discSpeedX = 5f;
    public float discSpeedY = 5f;
    public float rayDist = 1f;

    public float xRand;
    public float yRand;

    public Rigidbody2D thisRigidbody2d;
    public LayerMask wallMask;

    public GameObject self;

    public float freezeTimer;
    public float bounceTimer;

    public float discSpeedGeneral = 5f;

    public bool canMove;

    void Start()
    {
        freezeTimer = 100f;
        canMove = false;

        xRand = Random.Range(0.5f, 1.5f);
        yRand = Random.Range(0.5f, 1.5f);

        discSpeedX = discSpeedGeneral;
        discSpeedY = discSpeedGeneral;
    }

    void Update()
    {
        //VALID AS OF NOVEMBER 11th

        //Stay frozen until freezeTimer hits 0

        
        if (freezeTimer > 0)
        {
            Renderer r = self.GetComponent<Renderer>();
            Color selfAlpha = r.material.color;

            selfAlpha.a = 0.5f;
            freezeTimer--;

            canMove = false;
        }

        if (freezeTimer <= 0)
        {
            canMove = true;
        }
        


        //Create rays pointing to the top, bottom, left, and right sides of the object
        //If the top or bottom rays collide with a wall, flip the y speed
        //If the right or left rays collide with a wall, flip the x speed

        Ray rightRay = new Ray(transform.position, Vector2.right);
        Debug.DrawRay(rightRay.origin, rightRay.direction * rayDist, Color.white);
        RaycastHit2D hitRight = Physics2D.Raycast(rightRay.origin, rightRay.direction, rayDist, wallMask);

        if (Physics2D.Raycast(rightRay.origin, rightRay.direction, rayDist))
        {
            
            if (hitRight.collider != null)
            {
                discSpeedX = -discSpeedGeneral * xRand;
                bounceTimer = 10f;
            }
            
        }

        Ray leftRay = new Ray(transform.position, Vector2.left);
        Debug.DrawRay(leftRay.origin, leftRay.direction * rayDist, Color.white);
        RaycastHit2D hitLeft = Physics2D.Raycast(leftRay.origin, leftRay.direction, rayDist, wallMask);

        if (Physics2D.Raycast(leftRay.origin, leftRay.direction, rayDist))
        {

            
            if (hitLeft.collider != null)
            {
                discSpeedX = discSpeedGeneral * xRand;
                bounceTimer = 10f;
            }
            
        }

        Ray topRay = new Ray(transform.position, Vector2.up);
        Debug.DrawRay(topRay.origin, topRay.direction * rayDist, Color.white);
        RaycastHit2D hitTop = Physics2D.Raycast(topRay.origin, topRay.direction, rayDist, wallMask);

        if (Physics2D.Raycast(topRay.origin, topRay.direction, rayDist))
        {

            
            if (hitTop.collider != null)
            {
                discSpeedY = -discSpeedGeneral * yRand;
                bounceTimer = 10f;
            }

            
        }

        Ray bottomRay = new Ray(transform.position, Vector2.down);
        Debug.DrawRay(bottomRay.origin, bottomRay.direction * rayDist, Color.white);
        RaycastHit2D hitBottom = Physics2D.Raycast(bottomRay.origin, bottomRay.direction, rayDist, wallMask);

        if (Physics2D.Raycast(bottomRay.origin, bottomRay.direction, rayDist))
        {
            
            if (hitBottom.collider != null)
            {
                discSpeedY = discSpeedGeneral * yRand;
                bounceTimer = 10f;
            }
            
        }

        if (canMove == true)
        {
            //Always be moving on the X and Y axis
            thisRigidbody2d.velocity = new Vector3(discSpeedX, discSpeedY);
        }
        
        
    }
      

   
            
}
