using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //The GM is used to spawn the player and control the map as well as the menu.
    public GameObject playerPrefab;
    public Vector3 SpawnVector3;

    public LevelEditor zeroEditor;
    public LevelEditor oneEditor;
    public LevelEditor twoEditor;
    public LevelEditor threeEditor;
    public LevelEditor fourEditor;
    public LevelEditor fiveEditor;
    public LevelEditor sixEditor;
    public LevelEditor bossEditor;
    //camera vector
    public GameObject cam;
    //So basically I used the spawnvector3 to spawn, depend on which level we are in, the spawn location change accordingly.
    public bool inZero;
    public bool inOne;
    public bool inTwo;
    public bool inThree;
    public bool inFour;
    public bool inFive;
    public bool inSix;
    public bool inBoss;
    
    public Vector3 lvlZero;
    public Vector3 lvlOne;
    public Vector3 lvlTwo;
    public Vector3 lvlThree;
    public Vector3 lvlFour;
    public Vector3 lvlFive;
    public Vector3 lvlSix;
    public Vector3 lvlBoss;

    //below is used for cam lerp
    public Vector3 zeroCam;
    public Vector3 oneCam;
    public Vector3 twoCam;
    public Vector3 threeCam;
    public Vector3 fourCam;
    public Vector3 fiveCam;
    public Vector3 sixCam;
    public Vector3 bossCam;
    //public PlayerControl playerCont;
    void Start()
    {
        SpawnVector3 = lvlZero;
        Instantiate(playerPrefab, SpawnVector3, Quaternion.Euler(0, 0, 0));
        //the wordy place to see where the player is at
        inZero = true;
        inOne = false;
        inTwo = false;
        inThree = false;
        inFour = false;
        inFive = false;
        inSix = false;
        inBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //debug
        print(SpawnVector3);
        if (Input.GetKeyDown(KeyCode.R))
        { 
            //SceneManager.LoadScene("Harrying");
            Instantiate(playerPrefab, SpawnVector3, Quaternion.Euler(0, 0, 0));
        }
        //levelZero condition
        if (inZero == true)
        {
            if (zeroEditor.upDoor && !zeroEditor.upLocked)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    cam.transform.position = Vector3.Lerp(zeroCam,oneCam,1f);
                    inZero = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                }
            }
        }
        //level one condition
        if (inOne == true)
        {
            if (oneEditor.upDoor && !oneEditor.upLocked)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    cam.transform.position = Vector3.Lerp(oneCam,bossCam,1f);
                    inOne = false;
                    inBoss = true;
                    SpawnVector3 = lvlBoss;
                }
            }
            
            if (oneEditor.leftDoor && !oneEditor.leftLocked)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    cam.transform.position = Vector3.Lerp(oneCam,twoCam,1f);
                    inOne = false;
                    inTwo = true;
                    SpawnVector3 = lvlTwo;
                }
            }
            
            if (oneEditor.rightDoor && !oneEditor.rightLocked)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    cam.transform.position = Vector3.Lerp(oneCam,fourCam,1f);
                    inOne = false;
                    inFour = true;
                    SpawnVector3 = lvlFour;
                }
            }
        }
        
        //level 2 condition
        if (inTwo == true)
        {
            if (twoEditor.upDoor && !twoEditor.upLocked)
            {
                if (Input.GetKeyUp(KeyCode.W))
                {
                    cam.transform.position = Vector3.Lerp(twoCam,threeCam,1f);
                    inTwo = false;
                    inThree = true;
                    SpawnVector3 = lvlThree;
                }
            }

            if (twoEditor.rightDoor && !twoEditor.rightLocked)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    cam.transform.position = Vector3.Lerp(twoCam,oneCam,1f);
                    inTwo = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                }
            }
        }
        
        //level 3 condition
        if (inThree == true)
        {
            if (threeEditor.upDoor && !threeEditor.upLocked)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    cam.transform.position = Vector3.Lerp(threeCam,sixCam,1f);
                    inThree = false;
                    inSix = true;
                    SpawnVector3 = lvlSix;
                }
            }

            if (threeEditor.rightDoor && !threeEditor.rightLocked)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    cam.transform.position = Vector3.Lerp(threeCam,bossCam,1f);
                    inThree = false;
                    inBoss = true;
                    SpawnVector3 = lvlBoss;
                }
            }
            
            if (threeEditor.downDoor && !threeEditor.downLocked)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    cam.transform.position = Vector3.Lerp(threeCam,twoCam,1f);
                    inThree = false;
                    inTwo = true;
                    SpawnVector3 = lvlTwo;
                }
            }
        }
        
        //level 4 condition
        if (inFour == true)
        {
            if (fourEditor.upDoor && !fourEditor.upLocked)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    cam.transform.position = Vector3.Lerp(fourCam,fiveCam,1f);
                    inFour = false;
                    inFive = true;
                    SpawnVector3 = lvlFive;
                }
            }

            if (fourEditor.leftDoor && !fourEditor.leftLocked)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    cam.transform.position = Vector3.Lerp(fourCam,oneCam,1f);
                    inFour = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                }
            }
        }
        
        //level 5 condition
        if (inFive == true)
        {

            if (fiveEditor.leftDoor && !fiveEditor.leftLocked)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    cam.transform.position = Vector3.Lerp(fiveCam,bossCam,1f);
                    inFive = false;
                    inBoss = true;
                    SpawnVector3 = lvlBoss;
                }
            }
            
            if (fiveEditor.downDoor && !fiveEditor.downLocked)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    cam.transform.position = Vector3.Lerp(fiveCam,fourCam,1f);
                    inFive = false;
                    inFour = true;
                    SpawnVector3 = lvlFour;
                }
            }
        }
        
        //level 6 condition
        if (inSix == true)
        {

            if (sixEditor.downDoor && !sixEditor.downLocked)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    cam.transform.position = Vector3.Lerp(sixCam,threeCam,1f);
                    inSix = false;
                    inThree = true;
                    SpawnVector3 = lvlThree;
                }
            }
        }
        
        //level Boss condition
        if (inBoss == true)
        {

            if (bossEditor.leftDoor && !bossEditor.leftLocked)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    cam.transform.position = Vector3.Lerp(bossCam,threeCam,1f);
                    inBoss = false;
                    inThree = true;
                    SpawnVector3 = lvlThree;
                }
            }
            
            if (bossEditor.downDoor && !bossEditor.downLocked)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    cam.transform.position = Vector3.Lerp(bossCam,oneCam,1f);
                    inBoss = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                }
            }
            
            if (bossEditor.rightDoor && !bossEditor.rightLocked)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    cam.transform.position = Vector3.Lerp(bossCam,fiveCam,1f);
                    inBoss = false;
                    inFive = true;
                    SpawnVector3 = lvlFive;
                }
            }
        }
        


    }
}
