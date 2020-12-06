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

    public FakeDiscSpawn fakeAss;
    //this is used to determine player state
    public bool isAlive;
    
    //this is for lerp
    public float timeElapsed;
    public float lerpDuration;
    public bool canLerp;


    public float coolDownTimer;
    public float roomCoolDown;
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

        canLerp = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //this is used to determine if the player is alive
        if(GameObject.Find("PlayerPrefab(Clone)") != null)
        {
            print("player alive");
            isAlive = true;
        }
        else
        {
            print("player dead");
            isAlive = false;
        }
        
        
        
        roomCoolDown -= 1 * Time.deltaTime;
        //debug
        //print(SpawnVector3);
        //print(roomCoolDown + "/" + coolDownTimer);
        print(fakeAss.canSpawn);
        if (Input.GetKeyDown(KeyCode.R))
        { 
            //SceneManager.LoadScene("Harrying");
            Instantiate(playerPrefab, SpawnVector3, Quaternion.Euler(0, 0, 0));
            fakeAss.canSpawn = true;

        }
        //levelZero condition
        if (inZero == true)
        {
            if (zeroEditor.upDoor && !zeroEditor.upLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.W) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(zeroCam,oneCam,1f);
                    StartCoroutine(Lerp(zeroCam,oneCam));
                    inZero = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        //level one condition
        if (inOne == true)
        {
            if (oneEditor.upDoor && !oneEditor.upLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.W) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(oneCam,bossCam,1f);
                    StartCoroutine(Lerp(oneCam,bossCam));
                    inOne = false;
                    inBoss = true;
                    SpawnVector3 = lvlBoss;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
            
            if (oneEditor.leftDoor && !oneEditor.leftLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.A) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(oneCam,twoCam,1f);
                    StartCoroutine(Lerp(oneCam,twoCam));
                    inOne = false;
                    inTwo = true;
                    SpawnVector3 = lvlTwo;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
            
            if (oneEditor.rightDoor && !oneEditor.rightLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.D) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(oneCam,fourCam,1f);
                    StartCoroutine(Lerp(oneCam,fourCam));
                    inOne = false;
                    inFour = true;
                    SpawnVector3 = lvlFour;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        
        //level 2 condition
        if (inTwo == true)
        {
            if (twoEditor.upDoor && !twoEditor.upLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyUp(KeyCode.W) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(twoCam,threeCam,1f);
                    StartCoroutine(Lerp(twoCam,threeCam));
                    inTwo = false;
                    inThree = true;
                    SpawnVector3 = lvlThree;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }

            if (twoEditor.rightDoor && !twoEditor.rightLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.D) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(twoCam,oneCam,1f);
                    StartCoroutine(Lerp(twoCam,oneCam));
                    inTwo = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        
        //level 3 condition
        if (inThree == true)
        {
            if (threeEditor.upDoor && !threeEditor.upLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.W) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(threeCam,sixCam,1f);
                    StartCoroutine(Lerp(threeCam,sixCam));
                    inThree = false;
                    inSix = true;
                    SpawnVector3 = lvlSix;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }

            if (threeEditor.rightDoor && !threeEditor.rightLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.D) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(threeCam,bossCam,1f);
                    StartCoroutine(Lerp(threeCam,bossCam));
                    inThree = false;
                    inBoss = true;
                    SpawnVector3 = lvlBoss;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
            
            if (threeEditor.downDoor && !threeEditor.downLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.S) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(threeCam,twoCam,1f);
                    StartCoroutine(Lerp(threeCam,twoCam));
                    inThree = false;
                    inTwo = true;
                    SpawnVector3 = lvlTwo;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        
        //level 4 condition
        if (inFour == true)
        {
            if (fourEditor.upDoor && !fourEditor.upLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.W) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(fourCam,fiveCam,1f);
                    StartCoroutine(Lerp(fourCam,fiveCam));
                    inFour = false;
                    inFive = true;
                    SpawnVector3 = lvlFive;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }

            if (fourEditor.leftDoor && !fourEditor.leftLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.A) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(fourCam,oneCam,1f);
                    StartCoroutine(Lerp(fourCam,oneCam));
                    inFour = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        
        //level 5 condition
        if (inFive == true)
        {

            if (fiveEditor.leftDoor && !fiveEditor.leftLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.A) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(fiveCam,bossCam,1f);
                    StartCoroutine(Lerp(fiveCam,bossCam));
                    inFive = false;
                    inBoss = true;
                    SpawnVector3 = lvlBoss;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
            
            if (fiveEditor.downDoor && !fiveEditor.downLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.S) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(fiveCam,fourCam,1f);
                    StartCoroutine(Lerp(fiveCam,fourCam));
                    inFive = false;
                    inFour = true;
                    SpawnVector3 = lvlFour;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        
        //level 6 condition
        if (inSix == true)
        {

            if (sixEditor.downDoor && !sixEditor.downLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.S) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(sixCam,threeCam,1f);
                    StartCoroutine(Lerp(sixCam,threeCam));
                    inSix = false;
                    inThree = true;
                    SpawnVector3 = lvlThree;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        
        //level Boss condition
        if (inBoss == true)
        {

            if (bossEditor.leftDoor && !bossEditor.leftLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.A) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(bossCam,threeCam,1f);
                    StartCoroutine(Lerp(bossCam,threeCam));
                    inBoss = false;
                    inThree = true;
                    SpawnVector3 = lvlThree;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
            
            if (bossEditor.downDoor && !bossEditor.downLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.S) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(bossCam,oneCam,1f);
                    StartCoroutine(Lerp(bossCam,oneCam));
                    inBoss = false;
                    inOne = true;
                    SpawnVector3 = lvlOne;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
            
            if (bossEditor.rightDoor && !bossEditor.rightLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.D) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(bossCam,fiveCam,1f);
                    StartCoroutine(Lerp(bossCam,fiveCam));
                    inBoss = false;
                    inFive = true;
                    SpawnVector3 = lvlFive;
                    roomCoolDown = coolDownTimer;
                    canLerp = false;
                }
            }
        }
        
        IEnumerator Lerp(Vector3 startValue, Vector3 endValue)
        {
            timeElapsed = 0;
            while (timeElapsed < lerpDuration)
            {
                cam.transform.position = Vector3.Lerp(startValue,endValue,timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            cam.transform.position = endValue;
            canLerp = true;
        }

    }
}
