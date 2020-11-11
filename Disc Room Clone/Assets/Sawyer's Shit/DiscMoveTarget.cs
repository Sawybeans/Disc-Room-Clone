using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMoveTarget : MonoBehaviour
{

    public float discSpeedX = 5f;
    public float discSpeedY = 5f;
    public float rayDist = 1f;

    public float xRand;
    public float yRand;

    public Rigidbody2D thisRigidbody2d;
    public LayerMask wallMask;

    public GameObject self;
    public Transform player;

    public float freezeTimer;
    public float bounceTimer;
    public float targetTimer;
    public float aimTimer;

    public float discSpeedGeneral = 5f;

    public bool canMove;
    public bool targeting;

    // Start is called before the first frame update
    void Start()
    {
        freezeTimer = 100f;
        targetTimer = 1000f;
        aimTimer = 400f;

        xRand = Random.Range(0.5f, 1.5f);
        yRand = Random.Range(0.5f, 1.5f);

        canMove = false;
        targeting = false;

        discSpeedX = discSpeedGeneral;
        discSpeedY = discSpeedGeneral;
    }

    // Update is called once per frame
    void Update()
    {
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


        //Countdown until next targeted attack

        if (targetTimer > 0)
        {
            targeting = false;
            targetTimer--;
        }

        if (targetTimer <= 0)
        {
            discSpeedGeneral = 0f;
            targeting = true;

            aimTimer--;

            if (aimTimer <= 0)
            {
                freezeTimer = 1000f;
                aimTimer = 400f;
            }
        }


        if (targeting == false)
        {
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
                    discSpeedX = -discSpeedGeneral;
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
                    discSpeedX = discSpeedGeneral;
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
                    discSpeedY = -discSpeedGeneral;
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
                    discSpeedY = discSpeedGeneral;
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
}
