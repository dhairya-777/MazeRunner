using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePlayerManager : MonoBehaviour
{

    public Button player1Button;
    public Button player2Button;
    private bool buttonPressed = false;

    public AudioSource sound3;
    public void gotoHomeScene()
    {
        SceneManager.LoadScene("HomeScene");

    }

    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SelectPlayer1()
    {
        // Save the selected player index to player preferences
        // PlayerPrefs.SetInt("SelectedPlayerIndex", 0);

        // SceneManager.LoadScene("GameScene");
        //  FadeOutButton(player2Button);
        if (!buttonPressed)
        {
            // Save the selected player index to player preferences
            PlayerPrefs.SetInt("SelectedPlayerIndex", 0);

            // Fade out the unselected button
            FadeOutButton(player2Button);

            // Disable the unselected button
            DisableButton(player2Button);

            // Set buttonPressed to true to prevent further button presses
            buttonPressed = true;

           
            
        }

    }

    public void SelectPlayer2()
    {
        if (!buttonPressed)
        {
            // Save the selected player index to player preferences
            PlayerPrefs.SetInt("SelectedPlayerIndex", 1);

            // Fade out the unselected button
            FadeOutButton(player1Button);

            // Disable the unselected button
            DisableButton(player1Button);

            // Set buttonPressed to true to prevent further button presses
            buttonPressed = true;

           
        }

    }

    private void FadeOutButton(Button button)
    {
        // Get the button's image component
        Image buttonImage = button.GetComponent<Image>();

        // Fade out the button's image over 0.5 seconds
        buttonImage.CrossFadeAlpha(0, 0.5f, false);

        //Disable the button after it has faded out
        button.interactable = false;
       // Invoke("DisableButton", 0.5f);
    }

    private void DisableButton(Button button)
    {
        // Disable the button
        gameObject.SetActive(false);
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
