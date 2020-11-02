using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // IF ALIVE, THEN DO THE PLAYER BEHAVIORS
    //IF DEAD, CREATE THE BLOOD PREFAB, AND DESTROY CURRENT PLAYER PREFAB
    public bool alive;
    //Customizable player vars
    public float runSpeed;
    public float dashSpeed;
    //Animation stuff
    public Animator playerAnim;
    void Start()
    {
        //Initialize prefabs
        alive = true;
    }
    
    void Update()
    {
        if (alive)
        {
            //Basic player movements, under alive condition
            //UP
            if (Input.GetKey(KeyCode.UpArrow))
            {
                print("UP");
                playerAnim.SetBool("isUp",true);
                transform.Translate(0,runSpeed * Time.deltaTime,0);
            }
            
            //DOWN
            if (Input.GetKey(KeyCode.DownArrow))
            {
                print("DOWN");
                playerAnim.SetBool("isDown",true);
                transform.Translate(0,-runSpeed * Time.deltaTime,0);
            }
            
            //LEFT
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                print("LEFT");
                playerAnim.SetBool("isLeft",true);
                transform.Translate(-runSpeed * Time.deltaTime,0,0);
            }
            
            //RIGHT
            if (Input.GetKey(KeyCode.RightArrow))
            {
                print("RIGHT");
                playerAnim.SetBool("isRight",true);
                transform.Translate(runSpeed * Time.deltaTime,0,0);
            }
            
            
            
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                playerAnim.SetBool("isUp",false);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                playerAnim.SetBool("isDown",false);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAnim.SetBool("isLeft",false);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAnim.SetBool("isRight",false);
            }
        }
    }

    //All physics is here, currently I'm not sure if we need to use fixed update for collision detect or etc, so I'm commenting it out.
//    void FixedUpdate()
//    {
//        throw new NotImplementedException();
//    }
}
