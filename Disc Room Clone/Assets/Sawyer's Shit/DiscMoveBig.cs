using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMoveBig : MonoBehaviour
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

    public float discSpeedGeneral = 2f;

    public bool canMove;

    private SpriteRenderer sR;

    //Sound
    private bool launched;
    void Start()
    {
        freezeTimer = 60f;
        bounceTimer = 0f;
        canMove = false;

        xRand = Random.Range(0.5f, 1.5f);
        yRand = Random.Range(0.5f, 1.5f);
        
        discSpeedX = discSpeedGeneral;
        discSpeedY = discSpeedGeneral;
        sR = self.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Rotate(0,0,15);

        //Stay frozen until freezeTimer hits 0

        if (freezeTimer > 0)
        {
//            self.GetComponent<CircleCollider2D>().enabled = false;
//
//            Renderer r = self.GetComponent<Renderer>();
//            Color selfAlpha = r.material.color;
//
//            selfAlpha.a = 0.5f;
            sR.color = new Color(sR.color.r,sR.color.g,sR.color.b,0.39f);
            freezeTimer--;

            canMove = false;
        }

        if (freezeTimer <= 0)
        {
            self.GetComponent<CircleCollider2D>().enabled = true;
            sR.color = new Color(sR.color.r,sR.color.g,sR.color.b,1f);
            canMove = true;

            //Play Sound on Launch
            if (launched == false)
            {
                FindObjectOfType<AudioManager>().PlaySound("SawLaunch1", Random.Range(.75f, .95f));
                launched = true;
            }
          
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
                FindObjectOfType<AudioManager>().PlaySound("SawBounce1", Random.Range(.75f, .95f));
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
                FindObjectOfType<AudioManager>().PlaySound("SawBounce1", Random.Range(.75f, .95f));
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
                FindObjectOfType<AudioManager>().PlaySound("SawBounce1", Random.Range(.75f, .95f));
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
                FindObjectOfType<AudioManager>().PlaySound("SawBounce1", Random.Range(.75f, .95f));
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
