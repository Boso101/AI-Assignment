using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    [SerializeField] public GameObject helpMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(helpMenu.activeInHierarchy)
            {

            Time.timeScale = 1;
            helpMenu.SetActive(false);

            }
            else
            {
                Time.timeScale = 0;
                helpMenu.SetActive(true);

            }

        }
    }
}
