using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //The GM is used to spawn the player and control the map as well as the menu.
    public GameObject playerPrefab;
    public GameObject discSpawn;
    public GameObject wallDiscPrefab;
    public Vector3 SpawnVector3;

    public FakeDiscSpawn fakeAss;

    public keyboardNavigation navigator;
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
    void Update()
    {
        //this is used to determine if the player is alive
        if(GameObject.Find("PlayerPrefab(Clone)") != null)
        {
            //print("player alive");
            isAlive = true;
        }
        else
        {
            //print("player dead");
            isAlive = false;
        }
        roomCoolDown -= 1 * Time.deltaTime;

        // used to respawn the player as well as spawning the wall discs for room two, five, and six.
        if (Input.GetKeyDown(KeyCode.R) && isAlive == false) 
        {
            Instantiate(playerPrefab, SpawnVector3, Quaternion.Euler(0, 0, 0));
            FindObjectOfType<AudioManager>().PlaySound("Respawn", UnityEngine.Random.Range(.90f, 1f));
            fakeAss.canSpawn = true;
            fakeAss.counter = 0;
            navigator.timerIsRunning = true;
            if (inTwo)
            {
                Instantiate(wallDiscPrefab, new Vector3(-13.5f, 20.5f, 0), Quaternion.identity);
                Instantiate(wallDiscPrefab, new Vector3(-20.5f, 13.5f, 0), Quaternion.identity);
            }

            if (inFive)
            {
                Instantiate(wallDiscPrefab, new Vector3(20.5f, 37.5f, 0), Quaternion.identity);
                Instantiate(wallDiscPrefab, new Vector3(13.5f, 30.5f, 0), Quaternion.identity);
            }

            if (inSix)
            {
                Instantiate(wallDiscPrefab, new Vector3(-13.5f, 54.5f, 0), Quaternion.identity);
                Instantiate(wallDiscPrefab, new Vector3(-20.5f, 47.5f, 0), Quaternion.identity);
            }

        }

        #region conditions for different rooms
        //levelZero condition
        if (inZero == true)
        {
            if (zeroEditor.upDoor && !zeroEditor.upLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.W) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(zeroCam,oneCam,1f);
                    StartCoroutine(Lerp(zeroCam,oneCam));
                    //discSpawn.transform.position = lvlOne;
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
                    discSpawn.transform.position = lvlBoss;
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
                    discSpawn.transform.position = lvlTwo;
                    //Instantiate(wallDiscPrefab, new Vector3(-13.5f, 20.5f, 0), Quaternion.identity);
                    //Instantiate(wallDiscPrefab, new Vector3(-20.5f, 13.5f, 0), Quaternion.identity);
                    canLerp = false;
                }
            }
            
            if (oneEditor.rightDoor && !oneEditor.rightLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.D) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(oneCam,fourCam,1f);
                    StartCoroutine(Lerp(oneCam,fourCam));
                    discSpawn.transform.position = lvlFour;
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
                    discSpawn.transform.position = lvlThree;
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
                    discSpawn.transform.position = lvlOne;
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
                    discSpawn.transform.position = lvlSix;
                    inThree = false;
                    inSix = true;
                    SpawnVector3 = lvlSix;
                    roomCoolDown = coolDownTimer;
                    //Instantiate(wallDiscPrefab, new Vector3(-13.5f, 54.5f, 0), Quaternion.identity);
                    //Instantiate(wallDiscPrefab, new Vector3(-20.5f, 47.5f, 0), Quaternion.identity);
                    canLerp = false;
                }
            }

            if (threeEditor.rightDoor && !threeEditor.rightLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.D) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(threeCam,bossCam,1f);
                    StartCoroutine(Lerp(threeCam,bossCam));
                    discSpawn.transform.position = lvlBoss;
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
                    discSpawn.transform.position = lvlTwo;
                    inThree = false;
                    inTwo = true;
                    SpawnVector3 = lvlTwo;
                    roomCoolDown = coolDownTimer;
                    //Instantiate(wallDiscPrefab, new Vector3(-13.5f, 20.5f, 0), Quaternion.identity);
                    //Instantiate(wallDiscPrefab, new Vector3(-20.5f, 13.5f, 0), Quaternion.identity);
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
                    discSpawn.transform.position = lvlFive;
                    inFour = false;
                    inFive = true;
                    SpawnVector3 = lvlFive;
                    roomCoolDown = coolDownTimer;
                    //Instantiate(wallDiscPrefab, new Vector3(20.5f, 37.5f, 0), Quaternion.identity);
                    //Instantiate(wallDiscPrefab, new Vector3(13.5f, 30.5f, 0), Quaternion.identity);
                    canLerp = false;
                }
            }

            if (fourEditor.leftDoor && !fourEditor.leftLocked && roomCoolDown <= 0 && isAlive == false)
            {
                if (Input.GetKeyDown(KeyCode.A) && canLerp)
                {
                    //cam.transform.position = Vector3.Lerp(fourCam,oneCam,1f);
                    StartCoroutine(Lerp(fourCam,oneCam));
                    discSpawn.transform.position = lvlOne;
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
                    discSpawn.transform.position = lvlBoss;
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
                    discSpawn.transform.position = lvlFour;
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
                    discSpawn.transform.position = lvlThree;
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
                    discSpawn.transform.position = lvlThree;
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
                    discSpawn.transform.position = lvlOne;
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
                    discSpawn.transform.position = lvlFive;
                    inBoss = false;
                    inFive = true;
                    SpawnVector3 = lvlFive;
                    roomCoolDown = coolDownTimer;
                    //Instantiate(wallDiscPrefab, new Vector3(20.5f, 37.5f, 0), Quaternion.identity);
                    //Instantiate(wallDiscPrefab, new Vector3(13.5f, 30.5f, 0), Quaternion.identity);
                    canLerp = false;
                }
            }
        }
        #endregion
        
        
        //lerp function for cams.
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
