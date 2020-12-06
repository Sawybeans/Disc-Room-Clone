using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DiscMoveTiny: MonoBehaviour
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

    private SpriteRenderer sR;
    void Start()
    {
        freezeTimer = 60f;
        canMove = false;

        xRand = Random.Range(0.5f, 1.5f);
        yRand = Random.Range(0.5f, 1.5f);

        discSpeedX = Random.Range(-discSpeedGeneral, discSpeedGeneral);
        discSpeedY = Random.Range(-discSpeedGeneral, discSpeedGeneral);
        sR = self.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        canMove = true;
        transform.Rotate(0, 0, 10);
        /**
        if (freezeTimer > 0)
        {
            self.GetComponent<CircleCollider2D>().enabled = false;

            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 0.39f);
            freezeTimer--;

            canMove = false;
        }

        if (freezeTimer <= 0)
        {
            self.GetComponent<CircleCollider2D>().enabled = true;
            canMove = true;
            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 1f);
        }
        **/


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
                int rand = Random.Range(0, 2);
                //Play Sound
                if (rand == 0)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce1", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce2", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 2)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce3", UnityEngine.Random.Range(.90f, 1f));
                }
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
                int rand = Random.Range(0, 2);
                //Play Sound
                if (rand == 0)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce1", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce2", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 2)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce3", UnityEngine.Random.Range(.90f, 1f));
                }
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
                int rand = Random.Range(0, 2);
                //Play Sound
                if (rand == 0)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce1", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce2", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 2)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce3", UnityEngine.Random.Range(.90f, 1f));
                }
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
                int rand = Random.Range(0, 2);
                //Play Sound
                if (rand == 0)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce1", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce2", UnityEngine.Random.Range(.90f, 1f));
                }
                else if (rand == 2)
                {
                    FindObjectOfType<AudioManager>().PlaySound("SawBounce3", UnityEngine.Random.Range(.90f, 1f));
                }
            }

        }

        if (canMove == true)
        {
            //Always be moving on the X and Y axis
            thisRigidbody2d.velocity = new Vector3(discSpeedX, discSpeedY);
        }


    }




}
