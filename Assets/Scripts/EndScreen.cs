using System;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI points, laps, time, finalScore;
    public void CalculateScore()
    {
        var manager = GameManager.current;
        points.text = "Points: " + manager.points;
        time.text = "Time: " + TimeSpan.FromSeconds(manager.raceTime).ToString("mm':'ss'.'fff");
        var totalPoints = (int)(manager.points * Mathf.Max(120f - manager.raceTime, 0)) + manager.points * 10;
        finalScore.text = "Total Score: " + totalPoints;
        if (totalPoints > PlayerPrefs.GetInt("high", 0))
        {
            PlayerPrefs.SetInt("high", totalPoints);
            finalScore.text += " <color=yellow>HIGH SCORE!!!";
        }
            
    }
}