using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public float destroyPlayerDelay = 2f;

    public GameObject completeLevelUI;
    public GameObject secretLevelUI;
    public GameObject endlessEndUI;
    public GameObject player;

    public PlayerMovement movement;
    public Score scoreScript;
    public FollowPlayer followPlayerScript;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        int HighScore = PlayerPrefs.GetInt("Level", 0);
        if (HighScore == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void SecretCompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void SecretLevelTriggered()
    {
        movement.enabled = false;
        secretLevelUI.SetActive(true);
    }

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke(nameof(Restart), restartDelay);
        }
    }

    public void EndEndless ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            movement.enabled = false;
            scoreScript.enabled = false;
            followPlayerScript.enabled = false;

            FindObjectOfType<AudioManager>().Stop("EndlessModeMusic");

            PlayerPrefs.SetFloat("EndlessLatestScore", player.transform.position.z);
            float LatestScore = PlayerPrefs.GetFloat("EndlessLatestScore", 0);

            if (LatestScore > PlayerPrefs.GetFloat("EndlessHighscore", 0))
            {
                PlayerPrefs.SetFloat("EndlessHighscore", LatestScore);
                float Highscore = PlayerPrefs.GetFloat("EndlessHighscore", 0);
                scoreText.SetText(LatestScore.ToString("0"));
                highscoreText.SetText(Highscore.ToString("0"));
                Invoke(nameof(DestroyPlayerForEndlessMode), destroyPlayerDelay);
                return;
            }

            float OldHighscore = PlayerPrefs.GetFloat("EndlessHighscore", 0);

            scoreText.SetText(LatestScore.ToString("0"));
            highscoreText.SetText(OldHighscore.ToString("0"));

            Invoke(nameof(DestroyPlayerForEndlessMode), destroyPlayerDelay);
        }
    }

    private void DestroyPlayerForEndlessMode ()
    {
        endlessEndUI.SetActive(true);
        Destroy(player);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Loads current scene
    }

}
