using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour
{

    public AudioSource sound3;

    public void GoToChoosePlayer()
    {
        SceneManager.LoadScene("ChoosePlayerScene");
       
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        sound3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
