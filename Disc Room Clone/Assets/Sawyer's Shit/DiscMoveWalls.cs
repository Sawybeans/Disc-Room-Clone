using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMoveWalls : MonoBehaviour
{
    //If the ray hits a wall, destroy it until it hits another wall
    public bool canGoLeft = true;
    public bool canGoRight = true;
    public bool canGoUp = true;
    public bool canGoDown = true;

    public float discSpeedX = 5f;
    public float discSpeedY = 5f;
    public float discSpeedGeneral = 5f;

    public float rayDist = 1f;

    public Rigidbody2D thisRigidbody2d;
    public LayerMask wallMask;

    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        discSpeedX = discSpeedGeneral;
        discSpeedY = discSpeedGeneral;

        canGoDown = true;
        canGoLeft = false;
        canGoRight = false;
        canGoUp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Create rays pointing to the top, bottom, left, and right sides of the object
        //If the top ray collides, start moving to the left, if the left ray collides, start moving down, etc.
        //If a ray collides with a wall, destroy it until the disc is away from the wall
        transform.Rotate(0,0,30);
        if (canGoRight == true)
        {
            discSpeedX = discSpeedGeneral;
            discSpeedY = 0f;

            Ray rightRay = new Ray(transform.position, Vector2.right);
            Debug.DrawRay(rightRay.origin, rightRay.direction * rayDist, Color.white);
            RaycastHit2D hitRight = Physics2D.Raycast(rightRay.origin, rightRay.direction, rayDist, wallMask);

            if (Physics2D.Raycast(rightRay.origin, rightRay.direction, rayDist))
            {

                if (hitRight.collider != null)
                {
                    canGoRight = false;
                    canGoDown = true;
                    canGoLeft = false;
                    canGoUp = false;
                }

            }
        }

        if (canGoLeft == true)
        {
            discSpeedX = -discSpeedGeneral;
            discSpeedY = 0f;

            Ray leftRay = new Ray(transform.position, Vector2.left);
            Debug.DrawRay(leftRay.origin, leftRay.direction * rayDist, Color.white);
            RaycastHit2D hitLeft = Physics2D.Raycast(leftRay.origin, leftRay.direction, rayDist, wallMask);

            if (Physics2D.Raycast(leftRay.origin, leftRay.direction, rayDist))
            {


                if (hitLeft.collider != null)
                {
                    canGoRight = false;
                    canGoDown = false;
                    canGoLeft = false;
                    canGoUp = true;
                }

            }
        }

        if (canGoUp == true)
        {
            discSpeedX = 0f;
            discSpeedY = discSpeedGeneral;

            Ray topRay = new Ray(transform.position, Vector2.up);
            Debug.DrawRay(topRay.origin, topRay.direction * rayDist, Color.white);
            RaycastHit2D hitTop = Physics2D.Raycast(topRay.origin, topRay.direction, rayDist, wallMask);

            if (Physics2D.Raycast(topRay.origin, topRay.direction, rayDist))
            {

                if (hitTop.collider != null)
                {
                    canGoRight = true;
                    canGoDown = false;
                    canGoLeft = false;
                    canGoUp = false;

                }

            }
        }

        if (canGoDown == true)
        {
            discSpeedX = 0f;
            discSpeedY = -discSpeedGeneral;

            Ray bottomRay = new Ray(transform.position, Vector2.down);
            Debug.DrawRay(bottomRay.origin, bottomRay.direction * rayDist, Color.white);
            RaycastHit2D hitBottom = Physics2D.Raycast(bottomRay.origin, bottomRay.direction, rayDist, wallMask);

            if (Physics2D.Raycast(bottomRay.origin, bottomRay.direction, rayDist))
            {

                if (hitBottom.collider != null)
                {
                    canGoRight = false;
                    canGoDown = false;
                    canGoLeft = true;
                    canGoUp = false;
                }

            }
        }

        //Always be moving on the X and Y axis
        thisRigidbody2d.velocity = new Vector3(discSpeedX, discSpeedY);

    }
}
