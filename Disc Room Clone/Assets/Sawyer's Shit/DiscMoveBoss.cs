using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMoveBoss : MonoBehaviour
{

    // HUGE NOTE !!!!!!!
    // To get it working properly, you'll have to put this in the room without the spawner, then place a tiny disc in the room along with it
    // Then use that tiny disc object in the "Disc Tiny" field in the boss object's properties window

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

    public float newSpawn = 100f;

    public GameObject discTiny;

    private SpriteRenderer sR;

    //Audio
    private bool launched = false;
    void Start()
    {
        freezeTimer = 200f;
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

        if (newSpawn > 0)
        {
            newSpawn--;
        }

        if (newSpawn <= 0)
        {
            Instantiate(discTiny, self.transform.position, Quaternion.identity);
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("SawLaunch1", UnityEngine.Random.Range(1.1f, 1.2f));
            newSpawn = 100f;
        }

        transform.Rotate(0, 0, 15);

        if (freezeTimer > 0)
        {
            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 0.39f);
            freezeTimer--;

            canMove = false;
        }

        if (freezeTimer <= 0)
        {
            self.GetComponent<CircleCollider2D>().enabled = true;
            sR.color = new Color(sR.color.r, sR.color.g, sR.color.b, 1f);
            canMove = true;

            if (!launched)
            {
                //Play Sound
                FindObjectOfType<AudioManager>().PlaySound("SawLaunch1", UnityEngine.Random.Range(.80f, .85f));
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
