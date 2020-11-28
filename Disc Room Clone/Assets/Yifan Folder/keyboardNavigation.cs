using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class keyboardNavigation : MonoBehaviour
{

    public GameObject firstButton;

    public GameObject roomMenu, discsMenu, menuMenu;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
