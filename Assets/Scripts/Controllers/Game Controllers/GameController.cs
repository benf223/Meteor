using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private int score;
    private DifficultyManagerController difficultyManagerControl;

    [HideInInspector]
    public bool restarting;

    public GameObject difficultyManager;
    public Text scoreText;
    public GameObject pauseMenu;

    // Use this for initialization
    private void Start() {

        Time.timeScale = 1f;
        score = -1;
        difficultyManagerControl = difficultyManager.GetComponent<DifficultyManagerController>();
        difficultyManagerControl.StartTimer();
        Debug.Log("Start woo");
        restarting = false;
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }

    public void AddScore() {
        AddScore(10);
    }

    public void AddScore(int num) {
        score += num;
        scoreText.text = "Score: " + score;
    }

    private void OnDestroy() {
        if (!restarting) {
            UpdateHighscores();
            PlayerPrefs.SetString("score", "Score: " + score);
            difficultyManagerControl.PauseTimer();
        }
    }

    private void UpdateHighscores() {
        int[] current = new int[6];

        for (int i = 0; i < 5; ++i) {
            current[i] = PlayerPrefs.GetInt("Highscore" + i, 0);
        }

        current[5] = score;

        int indexMin;
        int temp;

        for (int i = 0; i < current.Length - 1; i++) {
            indexMin = i;

            for (int j = i + 1; j < current.Length; j++) {
                if (current[j].CompareTo(current[indexMin]) < 0) {
                    indexMin = j;
                }
            }

            temp = current[indexMin];
            current[indexMin] = current[i];
            current[i] = temp;
        }

        PlayerPrefs.SetInt("Highscore1", current[5]);
        PlayerPrefs.SetInt("Highscore2", current[4]);
        PlayerPrefs.SetInt("Highscore3", current[3]);
        PlayerPrefs.SetInt("Highscore4", current[2]);
        PlayerPrefs.SetInt("Highscore5", current[1]);
    }

    public int GetScore() {
        return score;
    }

    public void StoreScore() {
        PlayerPrefs.SetString("score", "Score: " + score);
    }

    public void Pause() {
        Time.timeScale = 0f;
        Debug.Log("Frozen?");
        pauseMenu.SetActive(true);
    }

    public void GoToMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameEnd");

    }

    public void StartMenuTimer() {
        Invoke("GoToMenu", 3.0f);
    }
}
