using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsMenu;


    // Start is called before the first frame update
    void Start()
    {
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        SettingsMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        SettingsMenu.SetActive(false);
    }
}
