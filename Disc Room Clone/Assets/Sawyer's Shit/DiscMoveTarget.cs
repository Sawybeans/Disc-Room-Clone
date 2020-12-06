using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMoveTarget : MonoBehaviour
{

    public float targetX;
    public float targetY;

    public float discSpeedX = 5f;
    public float discSpeedY = 5f;
    public float rayDist = 1f;

    public float xRand;
    public float yRand;

    public Rigidbody2D thisRigidbody2d;
    public LayerMask wallMask;

    public GameObject self;
    //public Transform player;
    public GameObject playerObject;

    public float freezeTimer;
    public float bounceTimer;
    public float targetTimer;
    public float aimTimer;

    public float discSpeedGeneral = 5f;

    public bool canMove;
    public bool targeting;

    private SpriteRenderer sR;

    private bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        freezeTimer = 100f;
        targetTimer = 1000f;
        aimTimer = 100f;

        xRand = Random.Range(0.5f, 1.5f);
        yRand = Random.Range(0.5f, 1.5f);

        canMove = false;
        targeting = false;

        playerObject = GameObject.FindGameObjectWithTag("Player");
        //Vector3 player = playerObject.transform.position;

        discSpeedX = discSpeedGeneral;
        discSpeedY = discSpeedGeneral;
        sR = self.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 15);

        //Stay frozen until freezeTimer hits 0

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

            if (!launched)
            {
                //Play Sound
                FindObjectOfType<AudioManager>().PlaySound("SawLaunch1", UnityEngine.Random.Range(.90f, 1f));
                launched = true;
            }
        }


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




        //Freeze disc when it can't move
        if (canMove == true)
        {
            Vector3 player = playerObject.transform.position;

            //Always be moving on the X and Y axis
            transform.position = Vector3.MoveTowards(transform.position, player, discSpeedGeneral * Time.deltaTime);
        }

        if (canMove == false)
        {
            thisRigidbody2d.velocity = new Vector3(0, 0);
        }

    }
}
