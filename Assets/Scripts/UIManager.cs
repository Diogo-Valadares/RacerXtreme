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
    public TMP_InputField nameInput;

    public void Start()
    {
        Time.timeScale = 1;
        current = this;
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

    public void StartGame()
    {
        GameManager.playerName = nameInput.text;
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
