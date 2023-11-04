using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneManager : MonoBehaviour
{
    public Material defaultSkyBox;
    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public void gotoHomeScene()
    {
        SceneManager.LoadScene("HomeScene");

    }

    public void MusicChoice1()
    {
        PlayerPrefs.SetString("SelectedMusic", "Music1");
        sound1.enabled = true;
        sound2.enabled = false;
        sound3.enabled = false;
    }

    public void MusicChoice2()
    {
        PlayerPrefs.SetString("SelectedMusic", "Music2");
        sound1.enabled = false;
        sound2.enabled = true;
        sound3.enabled = false;
    }

    public void MusicChoice3()
    {
        PlayerPrefs.SetString("SelectedMusic", "Music3");
        sound1.enabled = false;
        sound2.enabled = false;
        sound3.enabled = true;
    }

    public void Sky1()
    {
        RenderSettings.skybox = skybox1;
        PlayerPrefs.SetString("SelectedSkybox", "Sky1");
    }

    public void Sky2()
    {
        RenderSettings.skybox = skybox2;
        PlayerPrefs.SetString("SelectedSkybox", "Sky2");
    }

    public void Sky3()
    {
        RenderSettings.skybox = skybox3;
        PlayerPrefs.SetString("SelectedSkybox", "Sky3");
    }


    // Start is called before the first frame update
    void Start()
    {
        sound1.enabled = false;
        sound2.enabled = false;
        sound3.enabled = true;
        // Load the selected skybox value from PlayerPrefs or other storage
        string selectedSkybox = PlayerPrefs.GetString("SelectedSkybox", "Sky1");

        // Update the skybox based on the selected skybox value
        switch (selectedSkybox)
        {
            case "Sky1":
                RenderSettings.skybox = skybox1;
                break;
            case "Sky2":
                RenderSettings.skybox = skybox2;
                break;
            case "Sky3":
                RenderSettings.skybox = skybox3;
                break;
            default:
                // If the selected skybox value is not found, use the default skybox
                RenderSettings.skybox = defaultSkyBox;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
