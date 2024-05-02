using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject player;
    Dropdown resolutionDropDown;
    Slider mouseSensitivitySlider;
    TMPro.TextMeshPro sensitivityValueText;
    //resolutions array;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value;
        //change text
        player.GetComponent<F_PlayerLook>().mouseSensitivity = newSensitivity;

    }
    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void PopulateResDropDown()
    {
        int currentResIndex;
        //List<string> options = Screen.resolutions

    }
    public void ChangeReslolution(int resIndex)
    {

    }
}
