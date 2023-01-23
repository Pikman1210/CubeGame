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
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Dev code input");
            // put code here to switch to a scene that lets edit PlayerPrefs with a back button to welcome part of menu
        }
    }

    // Main Menu
    public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Goes to next scene in order
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

        string HighScore = PlayerPrefs.GetString("HighScore", "0");
        HighScoreSaveText.text = HighScore;
    }

    public void ResetSavaData ()
    {
        PlayerPrefs.DeleteAll();
    }

}
