using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour {

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    public TextMeshProUGUI SecretBeatenText;
    public TextMeshProUGUI HighScoreSaveText;
    // public TextMeshProUGUI EndlessScoreText;

    // UI Elements
    // Buttons
    public Button Level2Button;
    public Button Level3Button;
    public Button Level4Button;
    public Button Level5Button;
    public Button LevelSecretButton;
    public GameObject LevelSecretButtonObject;

    // Panels
    public GameObject WelcomePanelObject;
    public GameObject StartPanelObject;
    public GameObject LevelPanelObject;
    public GameObject OptionsPanelObject;
    public GameObject SavePanelObject;
    public GameObject DevPanelObject;

    private bool DevCodeSent = false;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space) && DevCodeSent == false)
        {
            Debug.Log("Dev Code");
            DevCodeSent = true;
            WelcomePanelObject.SetActive(false);
            StartPanelObject.SetActive(false);
            LevelPanelObject.SetActive(false);
            OptionsPanelObject.SetActive(false);
            SavePanelObject.SetActive(false);
            DevPanelObject.SetActive(true);
            Invoke("ResetDevCode", 1f);
        }
    }

    private void ResetDevCode ()
    {
        DevCodeSent = false;
        Debug.Log("Dev Code Reset");
    }

    // Main Menu
    public void StartGame (int Level)
    {
        SceneManager.LoadScene(Level);
        FindObjectOfType<AudioManager>().Play("Music");
    }

    public void StartEndless ()
    {
        Debug.Log("Start Endless Mode");
        SceneManager.LoadScene("Endless");
    }

    public void StartLevelEditor ()
    {
        Debug.Log("Start Level Editor");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit(); // Quits the game (duh)
    }

    // Settings Menu

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void setResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Sava Data Menu

    public void LoadSaveData ()
    {
        string SecretBeaten = PlayerPrefs.GetString("SecretBeaten", "false");
        SecretBeatenText.text = SecretBeaten;

        int HighScore = PlayerPrefs.GetInt("Level", 0);
        HighScoreSaveText.text = HighScore.ToString();
    }

    public void ResetSavaData ()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level", 1);
    }

    public void EditSaveData (int Data)
    {
        switch (Data)
        {
            case 1:
                PlayerPrefs.SetString("SecretBeaten", "true");
                break;
            case 2:
                int HighScore = PlayerPrefs.GetInt("Level");
                if (HighScore < 5f)
                {
                    HighScore = HighScore + 1;
                    PlayerPrefs.SetInt("Level", HighScore);
                    break;
                }
                break;
            default:
                Debug.LogError("Debug menu's shit is fucked");
                break;
        }
    }

    public void AvailableLevels ()
    {
        int Level = PlayerPrefs.GetInt("Level");

        switch (Level)
        {
            case 1:
                Level2Button.interactable = false;
                Level3Button.interactable = false;
                Level4Button.interactable = false;
                Level5Button.interactable = false;
                Invoke("CheckSecretLevel", 0);
                break;
            case 2:
                Level2Button.interactable = true;
                Level3Button.interactable = false;
                Level4Button.interactable = false;
                Level5Button.interactable = false;
                Invoke("CheckSecretLevel", 0);
                break;
            case 3:
                Level2Button.interactable = true;
                Level3Button.interactable = true;
                Level4Button.interactable = false;
                Level5Button.interactable = false;
                Invoke("CheckSecretLevel", 0);
                break;
            case 4:
                Level2Button.interactable = true;
                Level3Button.interactable = true;
                Level4Button.interactable = true;
                Level5Button.interactable = false;
                Invoke("CheckSecretLevel", 0);
                break;
            case 5:
                Level2Button.interactable = true;
                Level3Button.interactable = true;
                Level4Button.interactable = true;
                Level5Button.interactable = true;
                Invoke("CheckSecretLevel", 0);
                break;
            default:
                Level2Button.interactable = false;
                Level3Button.interactable = false;
                Level4Button.interactable = false;
                Level5Button.interactable = false;
                Invoke("CheckSecretLevel", 0);
                Debug.LogError("Using Default for Avaialble Levels");
                break;
        }
    }

    private void CheckSecretLevel ()
    {
        string SecretBeaten = PlayerPrefs.GetString("SecretBeaten", "false");

        if (SecretBeaten == "false")
        {
            LevelSecretButtonObject.SetActive(false);
        } else if (SecretBeaten == "true")
        {
            LevelSecretButtonObject.SetActive(true);
        } else
        {
            Debug.LogError("Save data for SecretBeaten fucked");
        }
    }

}
