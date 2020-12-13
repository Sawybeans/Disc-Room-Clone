using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public LevelController levelController;
    // Start is called before the first frame update
    public bool leftDoor;
    public bool leftLocked;
    public GameObject left;
    public Sprite leftSpriteOpen;
    public Sprite leftSpriteLock;
    
    public bool rightDoor;
    public bool rightLocked;
    public GameObject right;
    public Sprite rightSpriteOpen;
    public Sprite rightSpriteLock;
    
    public bool upDoor;
    public bool upLocked;
    public GameObject up;
    public Sprite upSpriteOpen;
    public Sprite upSpriteLock;
    
    public bool downDoor;
    public bool downLocked;
    public GameObject down;
    public Sprite downSpriteOpen;
    public Sprite downSpriteLock;

    public GameObject direction_w;
    public GameObject direction_a;
    public GameObject direction_s;
    public GameObject direction_d;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //control of the left door
        if (leftDoor)
        {
            left.SetActive(true);
            if (leftLocked)
            {
                left.GetComponent<SpriteRenderer>().sprite = leftSpriteLock;
            }
            else if (!leftLocked)
            {
                left.GetComponent<SpriteRenderer>().sprite = leftSpriteOpen;
            }
        }
        //control of the right door
        if (rightDoor)
        {
            right.SetActive(true);
            if (rightLocked)
            {
                right.GetComponent<SpriteRenderer>().sprite = rightSpriteLock;
            }
            else if (!rightLocked)
            {
                right.GetComponent<SpriteRenderer>().sprite = rightSpriteOpen;
            }
        }
        //control of the up door
        if (upDoor)
        {
            up.SetActive(true);
            if (upLocked)
            {
                up.GetComponent<SpriteRenderer>().sprite = upSpriteLock;
            }
            else if (!upLocked)
            {
                up.GetComponent<SpriteRenderer>().sprite = upSpriteOpen;
            }
        }
        //control of the down door
        if (downDoor)
        {
            down.SetActive(true);
            if (downLocked)
            {
                down.GetComponent<SpriteRenderer>().sprite = downSpriteLock;
            }
            else if (!downLocked)
            {
                down.GetComponent<SpriteRenderer>().sprite = downSpriteOpen;
            }
        }
    }
}
