using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI points, laps, time, finalScore;
    public void CalculateScore()
    {
        var highScores = PlayerPrefs.GetString("highScores", string.Empty).Split("\n").ToList();
        highScores.RemoveAll(score => score == string.Empty);
        var bestScore = highScores.Count == 0 ? 0 : int.Parse(highScores[0].Split("\t")[1]);
        var manager = GameManager.current;
        points.text = "Points: " + manager.points;
        time.text = "Time: " + TimeSpan.FromSeconds(manager.raceTime).ToString("mm':'ss'.'fff");
        var totalPoints = (int)(manager.points * Mathf.Max(120f - manager.raceTime, 0)) + manager.points * 10;
        finalScore.text = "Total Score: " + totalPoints;

        if (highScores.Count == 0 || totalPoints > bestScore)
        {
            highScores.Insert(0, GameManager.playerName + "\t" + totalPoints);
            finalScore.text += " <color=yellow>HIGH SCORE!!!";
        }
        else
        {
            var index = highScores.FindIndex(score => totalPoints > int.Parse(score.Split("\t")[1]));
            if (index < 0)
            {
                highScores.Add(GameManager.playerName + "\t" + totalPoints);
            }
            else
            {
                highScores.Insert(index, GameManager.playerName + "\t" + totalPoints);
            }
        }
        var saveString = string.Join("\n", highScores);
        PlayerPrefs.SetString("highScores", saveString);
        PlayerPrefs.Save();
        Debug.Log("\"" + PlayerPrefs.GetString("highScores") + "\"");
        return;
    }
}