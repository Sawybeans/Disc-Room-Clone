using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public bool alive;
    float dashSpeed;
    //Animation stuff
    public Animator playerAnim;
    //which is myself
    public float delayTime = 1f;

    public SpriteRenderer gSR;

    public float ghostDelayTime;
    //public ParticleSystem bloodBurst;
    void Start()
    {
        //Initialize prefabs
        alive = true;
        gSR = GetComponent<SpriteRenderer>();
        ghostDelayTime = delayTime;
    }
    
    void Update()
    {
        if (ghostDelayTime >= 0)
        {
            gSR.color = new Color32(255,0,0,(byte)(255 * (ghostDelayTime / delayTime)));

            ghostDelayTime -= Time.deltaTime;
            
        }
        else
        {
            Destroy(this.gameObject);
        }

        
        if (alive)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //print("UP");
                playerAnim.SetBool("isUp",true);
                playerAnim.SetBool("faceUp",false);
                //transform.Translate(0,(runSpeed + dashSpeed)* Time.deltaTime,0);
            }
            
            //DOWN
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //print("DOWN");
                playerAnim.SetBool("isDown",true);
                playerAnim.SetBool("faceDown",false);
                //transform.Translate(0,-(runSpeed + dashSpeed)* Time.deltaTime,0);
            }
            
            //LEFT
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //print("LEFT");
                playerAnim.SetBool("isLeft",true);
                playerAnim.SetBool("faceLeft",false);
                //transform.Translate(-(runSpeed + dashSpeed)* Time.deltaTime,0,0);
            }
            
            //RIGHT
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //print("RIGHT");
                playerAnim.SetBool("isRight",true);
                playerAnim.SetBool("faceRight",false);
                //transform.Translate((runSpeed + dashSpeed)* Time.deltaTime,0,0);
            }
            
            
            
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                playerAnim.SetBool("isUp",false);
                playerAnim.SetBool("faceUp",true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                playerAnim.SetBool("isDown",false);
                playerAnim.SetBool("faceDown",true);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAnim.SetBool("isLeft",false);
                playerAnim.SetBool("faceLeft",true);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAnim.SetBool("isRight",false);
                playerAnim.SetBool("faceRight",true);
            }
        }
    }
}
