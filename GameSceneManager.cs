using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSceneManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public TMP_Text tmScore;
    public TMP_Text tmHighScore;
    public TMP_Text tmTimetaken;

    
    
    public AudioClip gameOverSound;
    public AudioClip badcheckpointSound;
    public AudioClip checkpointSound;

    public AudioClip musicClip1;
    public AudioClip musicClip2;
    public AudioClip musicClip3;

    private int MAX_TIME = 15;
    private int SCORE_INCREMENT = 10;
    private int currentTime;
    private int currentScore;
    private int highScore;
    private int TIME_INCREMENT = 15;
    private int TIME_DECREMENT = 40;
    public Button Button1;
    public void gotoHomeScene()
    {
        SceneManager.LoadScene("SettingScene");

    }

    // Start is called before the first frame update
    void Start()
    {
        int selectedPlayerIndex = PlayerPrefs.GetInt("SelectedPlayerIndex", 0);

        // Activate the selected player object and deactivate the other player object
        if (selectedPlayerIndex == 0)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else if (selectedPlayerIndex == 1)
        {
            player1.SetActive(false);
            player2.SetActive(true);
        }

        Debug.Log("Game has Begin");

        currentTime = MAX_TIME;

        if (PlayerPrefs.HasKey("HighScore"))
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;

        //if (PlayerPrefs.HasKey("UserName"))
         //   tmName.text = PlayerPrefs.GetString("UserName");

        tmHighScore.text = "High Score: " + highScore;

        StartCoroutine("GainTime");

        string selectedMusic = PlayerPrefs.GetString("SelectedMusic");
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is not attached to the GameSceneManager game object!");
            return;
        }
        if (selectedMusic == "Music1")
        {
            audioSource.clip = musicClip1;
            audioSource.Play();
        }
        else if (selectedMusic == "Music2")
        {
            audioSource.clip = musicClip2;
            audioSource.Play();
        }
        else if (selectedMusic == "Music3")
        {

            audioSource.clip = musicClip3;
            audioSource.Play();
        }


    }

    IEnumerator GainTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentTime--;
            //SCORE_INCREMENT++;

            if (currentTime % 5 == 0)
            {
                currentScore += SCORE_INCREMENT;
                //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(scoreSound);
            }

            if (PlayerPrefs.HasKey("Score"))
            {
                if (PlayerPrefs.GetInt("Score") == 1)
                {
                    currentScore += 10;
                    currentTime += 10;

                    PlayerPrefs.SetInt("Score", 0);
                }

            }

            if (PlayerPrefs.HasKey("CheckPointHit"))
            {
                if (PlayerPrefs.GetInt("CheckPointHit") == 1)
                {
                  
                        player1.GetComponent<Animator>().SetTrigger("chaddancetrigger");
                       player2.GetComponent<Animator>().SetTrigger("dancetrigger");
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(checkpointSound);
                    GameObject.Find("CheckPointCanvas").GetComponent<PanelFader>().FadeOut();
                    currentTime += TIME_INCREMENT;
                    currentScore += 30;
                  
                    PlayerPrefs.SetInt("CheckPointHit", 0);
                }
            }

            if (PlayerPrefs.HasKey("BadCheckPointHit"))
            {
                if (PlayerPrefs.GetInt("BadCheckPointHit") == 1)
                {

                    GameObject.Find("BadCheckPointCanvas").GetComponent<PanelFader>().FadeOut();
                    currentTime -= TIME_DECREMENT;
                    currentScore -= 40;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(badcheckpointSound);
                    PlayerPrefs.SetInt("BadCheckPointHit", 0);
                }
            }

            if (PlayerPrefs.HasKey("GameOverHit"))
            {
                if (PlayerPrefs.GetInt("GameOverHit") == 1)
                {
                    GameOver();
                    PlayerPrefs.SetInt("GameOverHit", 0);
                }
            }

            if (PlayerPrefs.HasKey("WaterHit"))
            {
                if (PlayerPrefs.GetInt("WaterHit") == 1)
                {
                    GameOver();
                    PlayerPrefs.SetInt("WaterHit", 0);
                }
            }

  
            if (highScore < currentScore)
                PlayerPrefs.SetInt("HighScore", currentScore);

            if (currentTime <= 0)
                break;

        }
        GameOver();
    }

    public void GameOver()
    {
        if (highScore < currentScore)
            PlayerPrefs.SetInt("HighScore", currentScore);
        player2.GetComponent<Animator>().SetTrigger("dietrigger");
        player1.GetComponent<Animator>().SetTrigger("chaddancetrigger");
        PlayerPrefs.SetInt("GameOverHit", 0);
        GameObject.Find("GameOverCanvas").GetComponent<PanelFader>().FadeIn();

        tmHighScore.text = "High Score: " + highScore;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(gameOverSound);
        Debug.Log("Game Over !");
            }

    private void UpdateLabels()
    {
       

        tmScore.text = "Score: " + currentScore;
        tmTimetaken.text = "Time Left: " + currentTime;
        tmHighScore.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            player2.GetComponent<Animator>().SetTrigger("runtrigger");
            player1.GetComponent<Animator>().SetTrigger("chadruntrigger");

        UpdateLabels();

    }














}
