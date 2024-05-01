using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager current;
    [SerializeField]
    private Button play, pause, restart;
    [SerializeField]
    private GameObject pauseMenu, hud, GameoverMenu;
    public TextMeshProUGUI points, laps, time;

    public void Start()
    {
        current = this;
        play.onClick.AddListener(Play);
        pause.onClick.AddListener(Pause);
        restart.onClick.AddListener(Restart);
    }

    public void Play()
    {
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        hud.SetActive(false);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        hud.SetActive(false);
        GameoverMenu.SetActive(true);
        GameoverMenu.GetComponent<EndScreen>().CalculateScore();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
