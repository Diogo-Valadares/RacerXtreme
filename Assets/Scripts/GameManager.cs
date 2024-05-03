using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    public static string playerName;
    public float raceTime { get; private set; } = 0;
    public int laps { get; private set; } = -1;
    [field:SerializeField]
    public int lapCount { get; private set; } = 10;
    public int points { get; private set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        current = this;  
    }

    // Update is called once per frame
    void Update()
    {
        raceTime += Time.deltaTime;
        UIManager.current.time.text = "Time: " + System.TimeSpan.FromSeconds(raceTime).ToString("mm':'ss'.'fff");
    }

    public void AddLap()
    {
        laps++;
        UIManager.current.laps.text = "Laps: " + laps + "/" + lapCount;
        TargetSpawner.current.RespawnTargets();
        if (laps == lapCount)
        {
            UIManager.current.EndGame();
        }
    }
    
    public void AddPoints(int points)
    {
        this.points += points;
        UIManager.current.points.text = "Points: " + this.points;
    }

}
