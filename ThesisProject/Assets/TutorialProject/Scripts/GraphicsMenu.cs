using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject player;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    TMPro.TextMeshPro sensitivityValueText;
    Resolution[] resolutions;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDown();
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
        int currentResIndex=0;
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        for(int i = 0;  i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].height + "x" + resolutions[i].width);
            if (Screen.currentResolution.width == resolutions[i].width && Screen.currentResolution.height == resolutions[i].height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
    }
    public void ChangeReslolution(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width,resolutions[resIndex].height, Screen.fullScreenMode);
    }
}
