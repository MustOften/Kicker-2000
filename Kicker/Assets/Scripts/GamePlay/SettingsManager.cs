using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public Timer timer;
    public float CurrentDuration;
    public TMPro.TextMeshProUGUI Duration;
    public int GoalLimit;
    public TMPro.TextMeshProUGUI LimitGoals;
    public Ball ball;

    void Start()
    {
        CurrentDuration = 3;
        timer.gameTime = CurrentDuration * 60.0f;
        GoalLimit = 3;
        ball.TargetGoals = GoalLimit;
        
    }
    public void MoreTime()
    {
        CurrentDuration++;
        if (CurrentDuration > 9)
            CurrentDuration = 1;
        Duration.SetText(CurrentDuration.ToString());
        timer.gameTime = CurrentDuration * 60.0f;
    }

    public void LessTime()
    {
        CurrentDuration--;
        if (CurrentDuration < 1)
            CurrentDuration = 9;
        Duration.SetText(CurrentDuration.ToString());
        timer.gameTime = CurrentDuration * 60.0f;
    }

    public void MoreGoals()
    {
        GoalLimit++;
        if (GoalLimit > 9)
            GoalLimit = 1;
        LimitGoals.SetText(GoalLimit.ToString());
        ball.TargetGoals = GoalLimit;
    }

    public void LessGoals()
    {
        GoalLimit--;
        if (GoalLimit < 1)
            GoalLimit = 9;
        LimitGoals.SetText(GoalLimit.ToString());
        ball.TargetGoals = GoalLimit;
    }

    
}
