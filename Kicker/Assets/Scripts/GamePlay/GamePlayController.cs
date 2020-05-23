using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayController : MonoBehaviour
{
    private float timer;
    private float GOtimer;
    private bool isPause;
    private bool isGameOver;
    public enum State
    {
        Play, GameOver, Pause, Goal
    }

    public State state { get; private set; }
    public GameObject menu;
    public GameObject WinningMenu;
    public GameObject GoalShow;
    public GameObject CharacterMenu;
    public GameObject GAME;
    public GameObject SettingsMenu;
    public GameObject Controls;
    public Ball ball;
    public Timer TimeCounter;
    public SettingsManager settings;
    public float delayToStartSeconds;
    public TMPro.TextMeshProUGUI startCounter;
    private float counterTextSize;
    [HideInInspector]
    public float starttime = 100.0f;



    private void Start()
    {
        SettingsMenu.SetActive(false);
        GoalShow.SetActive(false);
        menu.SetActive(false);
        WinningMenu.SetActive(false);
        GAME.SetActive(false);
        CharacterMenu.SetActive(true);
        isGameOver = false;
        counterTextSize = startCounter.fontSize;
        startCounter.gameObject.SetActive(false);
        ball.ballIsActive = false;
        ball.BallScored += Goal;
        ball.EndGame += GameOver;
    }

    void Update()
    {
            Time.timeScale = timer;

        if (isGameOver == true)
        {
            timer = 0;
        }
        else if (isGameOver == false)
        {
            timer = 1f;

            if (!ball.ballIsActive)
            {
                ball.gameObject.transform.position = ball.BallStartPosition;
            }

            if (transform.position.y < 0)
            {
                ball.ballIsActive = false;
                gameObject.transform.position = ball.BallStartPosition;
            }


            if (CharacterMenu.activeSelf == false)
            {
                if (SettingsMenu.activeSelf == false)
                {
                    if (state != State.Goal)
                    {
                        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
                        {
                            isPause = true;
                            Pause();
                        }
                        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
                        {
                            isPause = false;
                            Play();
                        }
                        if (isPause == true)
                        {
                            timer = 0;
                        }
                        else if (isPause == false)
                        {
                            timer = 1f;
                        }
                    }
                }
            }
            if (SettingsMenu.activeSelf == true)
            {
                timer = 0;
            }
            if (CharacterMenu.activeSelf == true)
            {
                timer = 0;
            }
        }

    }

    public void ToSettings()
    {
        SettingsMenu.SetActive(true);
        CharacterMenu.SetActive(false);
    }

    public void BackToCharacters()
    {
        SettingsMenu.SetActive(false);
        CharacterMenu.SetActive(true);
    }

    public void Play()
    {
        Controls.SetActive(false);
        isGameOver = false;
        GoalShow.SetActive(false);
        menu.SetActive(false);
        WinningMenu.SetActive(false);
        CharacterMenu.SetActive(false);
        GAME.SetActive(true);
        isPause = false;
        ball.ballIsActive = true;
        ball.rigidbody.useGravity = true;
        state = State.Play;
    }

    public void Goal()
    {
        state = State.Goal;
        GoalShow.SetActive(true);
        StartCoroutine(DelayToStart());
    }


    public void GameOver()
    {
        startCounter.gameObject.SetActive(false);
        WinningMenu.SetActive(true);
        GoalShow.SetActive(false);
        state = State.GameOver;
        isGameOver = true;
        ball.ballIsActive = false;
    }

    public void Pause()
    {
        Controls.SetActive(false);
        isGameOver = false;
        isPause = true;
        state = State.Pause;
        menu.SetActive(true);
    }
    public void ToControls()
    {
        menu.SetActive(false);
        Controls.SetActive(true);
    }
    public void BackToPause()
    {
        menu.SetActive(true);
        Controls.SetActive(false);
    }
    public void Restart()
    {
        isGameOver = false;
        GoalShow.SetActive(false);
        menu.SetActive(false);
        WinningMenu.SetActive(false);
        CharacterMenu.SetActive(true);
        GAME.SetActive(false);
        ball.ballIsActive = false;
        TimeCounter.gameTime = settings.CurrentDuration*60.0f;
        ball.RightGoals = 0;
        ball.LeftGoals = 0;
        ball.LeftGoalCount.SetText(ball.RightGoals.ToString());
        ball.RightGoalCount.SetText(ball.LeftGoals.ToString());
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator DelayToStart()
    {
        float starttime = delayToStartSeconds;
        startCounter.gameObject.SetActive(true);
        startCounter.SetText(starttime.ToString());
        float timeUpdate = Time.time;

        while (starttime > 0)
        {
            startCounter.fontSize = counterTextSize * (1 - (Time.time - timeUpdate));
            if ((Time.time - timeUpdate) >= 1)
            {
                starttime -= 1;
                timeUpdate = Time.time;
                startCounter.SetText(starttime.ToString());
            }
            yield return null;
        }
        startCounter.gameObject.SetActive(false);
        GoalShow.SetActive(false);
        state = State.Play;
        if (!ball.ballIsActive)
        {
            ball.rigidbody.AddForce(ball.ballInitialForce);
            ball.ballIsActive = true;
            ball.rigidbody.useGravity = true;
        }

    }
}