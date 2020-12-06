using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class keyboardNavigation : MonoBehaviour
{

    public GameObject firstButton;

    public GameObject roomMenu, discsMenu, menuMenu;

    private GameManager GameManagerScript;

    public LevelEditor oneEditor;

    public LevelEditor threeEditor;

    public LevelEditor fiveEditor;
    
    //this is used for timer - Harry, copying Donovan's timer codes
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI highScore;
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    
    public float timerHighestZero;
    public float timerHighestOne;
    public float timerHighestTwo;
    public float timerHighestThree;
    public float timerHighestFour;
    public float timerHighestFive;
    public float timerHighestSix;
    public float timerHighestBoss;
    
    // Start is called before the first frame update
    void Awake()
    {
        GameManagerScript = GameObject.FindObjectOfType<GameManager>();
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //this is the timer
        #region roomTimerDisplay

        if (GameManagerScript.inZero)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
                    {
                        if (timeRemaining >= timerHighestZero)
                        {
                            timerHighestZero = timeRemaining;
                        }
                        DisplayTime(timeRemaining, timerHighestZero);
                        timeRemaining += Time.deltaTime;
                    }
                    else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
                    {
                        //Debug.Log("Player dead!");
                        timeRemaining = 0;
                        DisplayTime(timeRemaining, timerHighestZero);
                        timerIsRunning = false;
                    }
                    else
                    {
                        //Debug.Log("Player dead!");
                        timeRemaining = 0;
                        DisplayTime(timeRemaining, timerHighestZero);
                        timerIsRunning = false;
                    }
        }
        
        if (GameManagerScript.inOne)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
            {
                if (timeRemaining >= timerHighestOne)
                {
                    timerHighestOne = timeRemaining;
                }
                DisplayTime(timeRemaining, timerHighestOne);
                timeRemaining += Time.deltaTime;
            }
            else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestOne);
                timerIsRunning = false;
            }
            else
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestOne);
                timerIsRunning = false;
            }
        }
        
        if (GameManagerScript.inTwo)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
            {
                if (timeRemaining >= timerHighestTwo)
                {
                    timerHighestTwo = timeRemaining;
                }
                DisplayTime(timeRemaining, timerHighestTwo);
                timeRemaining += Time.deltaTime;
            }
            else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestTwo);
                timerIsRunning = false;
            }
            else
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestTwo);
                timerIsRunning = false;
            }
        }
        
        
        if (GameManagerScript.inThree)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
            {
                if (timeRemaining >= timerHighestThree)
                {
                    timerHighestThree = timeRemaining;
                }
                DisplayTime(timeRemaining, timerHighestThree);
                timeRemaining += Time.deltaTime;
            }
            else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestThree);
                timerIsRunning = false;
            }
            else
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestThree);
                timerIsRunning = false;
            }
        }
        
        if (GameManagerScript.inFour)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
            {
                if (timeRemaining >= timerHighestFour)
                {
                    timerHighestFour = timeRemaining;
                }
                DisplayTime(timeRemaining, timerHighestFour);
                timeRemaining += Time.deltaTime;
            }
            else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestFour);
                timerIsRunning = false;
            }
            else
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestFour);
                timerIsRunning = false;
            }
        }
        
        if (GameManagerScript.inFive)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
            {
                if (timeRemaining >= timerHighestFive)
                {
                    timerHighestFive = timeRemaining;
                }
                DisplayTime(timeRemaining, timerHighestFive);
                timeRemaining += Time.deltaTime;
            }
            else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestFive);
                timerIsRunning = false;
            }
            else
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestFive);
                timerIsRunning = false;
            }
        }
        
        if (GameManagerScript.inSix)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
            {
                if (timeRemaining >= timerHighestSix)
                {
                    timerHighestSix = timeRemaining;
                }
                DisplayTime(timeRemaining, timerHighestSix);
                timeRemaining += Time.deltaTime;
            }
            else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestSix);
                timerIsRunning = false;
            }
            else
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestSix);
                timerIsRunning = false;
            }
        }
        
        if (GameManagerScript.inBoss)
        {
            if (timerIsRunning && GameObject.Find("PlayerPrefab(Clone)") != null)
            {
                if (timeRemaining >= timerHighestBoss)
                {
                    timerHighestBoss = timeRemaining;
                }
                DisplayTime(timeRemaining, timerHighestBoss);
                timeRemaining += Time.deltaTime;
            }
            else if(Input.GetKeyDown(KeyCode.R) && GameManagerScript.isAlive == false)
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestBoss);
                timerIsRunning = false;
            }
            else
            {
                Debug.Log("Player dead!");
                timeRemaining = 0;
                DisplayTime(timeRemaining, timerHighestBoss);
                timerIsRunning = false;
            }
        }
        #endregion
        
        //this is used to unlock the boss room
        if (timerHighestZero >= 15f &&
            timerHighestOne >= 15f &&
            timerHighestTwo >= 15f &&
            timerHighestThree >= 15f &&
            timerHighestFour >= 15f &&
            timerHighestFive >= 15f &&
            timerHighestSix >= 15f)
        {
            oneEditor.upLocked = false;
            threeEditor.rightLocked = false;
            fiveEditor.leftLocked = false;
        }
        //win condition
        if (timerHighestBoss >= 40f)
        {
            Application.LoadLevel("end screen");
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.Escape) && !roomMenu.activeInHierarchy && !discsMenu.activeInHierarchy && !menuMenu.activeInHierarchy)
        {
            PauseMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Unpause();
        }
    }

    public void DisplayTime(float timeToDisplay, float highestScore)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = Mathf.FloorToInt((timeToDisplay * 100) % 100);

        
        
        float minutesMax = Mathf.FloorToInt(highestScore / 60);
        float secondsMax = Mathf.FloorToInt(highestScore % 60);
        float milliSecondsMax = Mathf.FloorToInt((highestScore * 100) % 100);
        
        timeText.text = string.Format("Score: " + "{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
        highScore.text = string.Format("High Score: " + "{0:00}:{1:00}:{2:00}", minutesMax, secondsMax, milliSecondsMax);
        timeToDisplay += 1;


    }
    
    void PauseMenu()
    {
        if (!roomMenu.activeInHierarchy)
        {
            roomMenu.SetActive(true);
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(firstButton);

            //Enable Lowpass
            FindObjectOfType<AudioManager>().lowPassEnable();
        }
        else
        {
            roomMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    void Unpause()
    {
        if (discsMenu.activeInHierarchy)
        {
            discsMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (menuMenu.activeInHierarchy)
        {
            menuMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (roomMenu.activeInHierarchy)
        {
            roomMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        //Enable Lowpass
        FindObjectOfType<AudioManager>().lowPassDisable();
    }

    //void discsMenuOpened()
    //{
    //discsMenu.SetActive(true);
    //roomMenu.SetActive(false);
    //menuMenu.SetActive(false);
    //}

    //void discsMenuClosed()
    //{
    //discsMenu.SetActive(true);
    //}

    public void enterLevel1()
    {
        if (GameManagerScript.isAlive == false)
        {
            GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.twoCam, GameManagerScript.oneCam, 1f);
            GameManagerScript.inOne = true;
            GameManagerScript.inTwo = false;
            GameManagerScript.inThree = false;
            GameManagerScript.inFour = false;
            GameManagerScript.inFive = false;
            GameManagerScript.inSix = false;
            GameManagerScript.inBoss = false;
            GameManagerScript.SpawnVector3 = GameManagerScript.lvlOne;
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("CameraTransition", UnityEngine.Random.Range(.90f, 1f));
        }
        else
        {
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("Denied", UnityEngine.Random.Range(.90f, 1f));
        }

    }

    public void enterLevel2()
    {
        if (GameManagerScript.isAlive == false)
        {
            GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.oneCam, GameManagerScript.twoCam, 1f);
            GameManagerScript.inOne = false;
            GameManagerScript.inTwo = true;
            GameManagerScript.inThree = false;
            GameManagerScript.inFour = false;
            GameManagerScript.inFive = false;
            GameManagerScript.inSix = false;
            GameManagerScript.inBoss = false;
            GameManagerScript.SpawnVector3 = GameManagerScript.lvlTwo;
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("CameraTransition", UnityEngine.Random.Range(.90f, 1f));
        }
        else
        {
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("Denied", UnityEngine.Random.Range(.90f, 1f));
        }
    }

    public void enterLevel3()
    {
        if (GameManagerScript.isAlive == false)
        {
            GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.twoCam, GameManagerScript.threeCam, 1f);
            GameManagerScript.inOne = false;
            GameManagerScript.inTwo = false;
            GameManagerScript.inThree = true;
            GameManagerScript.inFour = false;
            GameManagerScript.inFive = false;
            GameManagerScript.inSix = false;
            GameManagerScript.inBoss = false;
            GameManagerScript.SpawnVector3 = GameManagerScript.lvlThree;
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("CameraTransition", UnityEngine.Random.Range(.90f, 1f));
        }
        else
        {
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("Denied", UnityEngine.Random.Range(.90f, 1f));
        }
    }

    public void enterLevel4()
    {
        if (GameManagerScript.isAlive == false)
        {
            GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.oneCam, GameManagerScript.fourCam, 1f);
            GameManagerScript.inOne = false;
            GameManagerScript.inTwo = false;
            GameManagerScript.inThree = false;
            GameManagerScript.inFour = true;
            GameManagerScript.inFive = false;
            GameManagerScript.inSix = false;
            GameManagerScript.inBoss = false;
            GameManagerScript.SpawnVector3 = GameManagerScript.lvlFour;
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("CameraTransition", UnityEngine.Random.Range(.90f, 1f));
        }
        else
        {
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("Denied", UnityEngine.Random.Range(.90f, 1f));
        }
    }

    public void enterLevel5()
    {
        if (GameManagerScript.isAlive == false)
        {
            GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.fourCam, GameManagerScript.fiveCam, 1f);
            GameManagerScript.inOne = false;
            GameManagerScript.inTwo = false;
            GameManagerScript.inThree = false;
            GameManagerScript.inFour = false;
            GameManagerScript.inFive = true;
            GameManagerScript.inSix = false;
            GameManagerScript.inBoss = false;
            GameManagerScript.SpawnVector3 = GameManagerScript.lvlFive;
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("CameraTransition", UnityEngine.Random.Range(.90f, 1f));
        }
        else
        {
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("Denied", UnityEngine.Random.Range(.90f, 1f));
        }
    }

    public void enterLevel6()
    {
        if (GameManagerScript.isAlive == false)
        {
            GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.threeCam, GameManagerScript.sixCam, 1f);
            GameManagerScript.inOne = false;
            GameManagerScript.inTwo = false;
            GameManagerScript.inThree = false;
            GameManagerScript.inFour = false;
            GameManagerScript.inFive = false;
            GameManagerScript.inSix = true;
            GameManagerScript.inBoss = false;
            GameManagerScript.SpawnVector3 = GameManagerScript.lvlSix;
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("CameraTransition", UnityEngine.Random.Range(.90f, 1f));
        }
        else
        {
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("Denied", UnityEngine.Random.Range(.90f, 1f));
        }
    }

    public void enterLevelBoss()
    {
        if (GameManagerScript.isAlive == false)
        {
            GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.oneCam, GameManagerScript.bossCam, 1f);
            GameManagerScript.inOne = false;
            GameManagerScript.inTwo = false;
            GameManagerScript.inThree = false;
            GameManagerScript.inFour = false;
            GameManagerScript.inFive = false;
            GameManagerScript.inSix = false;
            GameManagerScript.inBoss = true;
            GameManagerScript.SpawnVector3 = GameManagerScript.lvlBoss;
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("CameraTransition", UnityEngine.Random.Range(.90f, 1f));
        }
        else
        {
            //Play Sound
            FindObjectOfType<AudioManager>().PlaySound("Denied", UnityEngine.Random.Range(.90f, 1f));
        }
    }
}
