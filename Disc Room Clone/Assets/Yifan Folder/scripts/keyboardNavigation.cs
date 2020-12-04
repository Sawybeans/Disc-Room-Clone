using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class keyboardNavigation : MonoBehaviour
{

    public GameObject firstButton;

    public GameObject roomMenu, discsMenu, menuMenu;

    private GameManager GameManagerScript;

    // Start is called before the first frame update
    void Awake()
    {
        GameManagerScript = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !roomMenu.activeInHierarchy && !discsMenu.activeInHierarchy && !menuMenu.activeInHierarchy)
        {
            PauseMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Unpause();
        }
    }

    void PauseMenu()
    {
        if (!roomMenu.activeInHierarchy)
        {
            roomMenu.SetActive(true);
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(firstButton);

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
        GameManagerScript.cam.transform.position = Vector3.Lerp(GameManagerScript.twoCam, GameManagerScript.oneCam, 1f);
        GameManagerScript.inOne = true;
        GameManagerScript.inTwo = false;
        GameManagerScript.inThree = false;
        GameManagerScript.inFour = false;
        GameManagerScript.inFive = false;
        GameManagerScript.inSix = false;
        GameManagerScript.inBoss = false;
        GameManagerScript.SpawnVector3 = GameManagerScript.lvlOne;
    }

    public void enterLevel2()
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
    }

    public void enterLevel3()
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
    }

    public void enterLevel4()
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
    }

    public void enterLevel5()
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
    }

    public void enterLevel6()
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
    }

    public void enterLevelBoss()
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
    }
}
