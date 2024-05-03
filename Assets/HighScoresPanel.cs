using TMPro;
using UnityEngine;

public class HighScoresPanel : MonoBehaviour
{
    [SerializeField]
    private Transform highScoresPanel;
    [SerializeField]
    private GameObject exampleScore;
    void Start()
    {
        var highScores = PlayerPrefs.GetString("highScores", string.Empty);
        if (highScores == string.Empty) return;
        foreach (var score in highScores.Split('\n'))
        {
            var scoreObject = Instantiate(exampleScore, highScoresPanel);
            scoreObject.SetActive(true);
            var nameAndValue = score.Split('\t');
            Debug.Log(nameAndValue[0]);
            Debug.Log(nameAndValue[1]);
            scoreObject.GetComponent<TextMeshProUGUI>().text = nameAndValue[0] + " - " + nameAndValue[1];
        }
    }
}
