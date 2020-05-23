using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int TargetGoals;
    public Rigidbody rigidbody;
    public static Ball Instance;
    public TMPro.TextMeshProUGUI LeftGoalCount;
    public TMPro.TextMeshProUGUI RightGoalCount;
    public TMPro.TextMeshProUGUI WinnerName;
    
    public Timer timer;
    public float spotRange;
    public int LeftGoals = 0;
    public int RightGoals= 0;
    public AudioSource GoalSound;
    public AudioSource KickSound;
    [HideInInspector]
    public Vector3 BallStartPosition;
    [HideInInspector]
    public bool ballIsActive;
    [HideInInspector]
    public Vector3 ballInitialForce;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ballInitialForce = new Vector3(Random.Range(-spotRange, spotRange), -5, Random.Range(-spotRange, spotRange));
        BallStartPosition = gameObject.transform.position;
        LeftGoalCount.SetText(LeftGoals.ToString());
        RightGoalCount.SetText(RightGoals.ToString());
        rigidbody.AddForce(ballInitialForce);
        ballIsActive = true;
        rigidbody.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y<0)
        {
            gameObject.transform.position = BallStartPosition;
        }
        if (LeftGoals == TargetGoals || RightGoals == TargetGoals)
        {
            if (LeftGoals == TargetGoals)
                WinnerName.SetText("HOME TEAM WIN");
            if (RightGoals == TargetGoals)
                WinnerName.SetText("AWAY TEAM WIN");

            EndGame.Invoke();
        }

        int gametime = timer.IntGameTime;
        if (gametime/60 == 0 && gametime%60 == 0)
        {
            if (RightGoals > LeftGoals)
                WinnerName.SetText("PLAYER 2 WIN!");
            else if (RightGoals < LeftGoals)
                WinnerName.SetText("PLAYER 1 WIN!");
            else if (RightGoals == LeftGoals)
                WinnerName.SetText("DRAW");

            EndGame.Invoke();
        }

        
    }
    public event System.Action EndGame;
    public event System.Action BallScored;
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        if(tag != "Floor")
        {
            if (!KickSound.isPlaying)
            {
                KickSound.Play();
            }
        }


        if (tag == "GoalLeft")
        {
            if(!GoalSound.isPlaying)
            {
                GoalSound.Play();
            }
            RightGoals++;
            LeftGoalCount.SetText(RightGoals.ToString());
            gameObject.transform.position = BallStartPosition;
            ballIsActive = false;
            rigidbody.useGravity = false;
            BallScored.Invoke();
            
        }

        if (tag == "GoalRight")
        {
            if (!GoalSound.isPlaying)
            {
                GoalSound.Play();
            }
            LeftGoals++;
            RightGoalCount.SetText(LeftGoals.ToString());
            gameObject.transform.position = BallStartPosition;
            ballIsActive = false;
            rigidbody.useGravity = false;
            BallScored.Invoke();
        }
    }


}
