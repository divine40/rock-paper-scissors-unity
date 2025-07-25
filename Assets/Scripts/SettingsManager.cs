using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;

    private void Start()
    {
        // Load saved preferences or use default (1 = true)
        bool isMusicOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        bool isSFXOn = PlayerPrefs.GetInt("SFXEnabled", 1) == 1;

        musicToggle.isOn = isMusicOn;
        sfxToggle.isOn = isSFXOn;

        // Apply audio settings immediately
        ApplySettings();

        // Add listeners AFTER setting isOn values to avoid premature trigger
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
        sfxToggle.onValueChanged.AddListener(OnSFXToggleChanged);
    }

    // Called when Music toggle is changed
    public void OnMusicToggleChanged(bool isOn)
    {
        PlayerPrefs.SetInt("MusicEnabled", isOn ? 1 : 0);
        AudioManager.Instance.ToggleMusic(isOn);
    }

    // Called when SFX toggle is changed
    public void OnSFXToggleChanged(bool isOn)
    {
        PlayerPrefs.SetInt("SFXEnabled", isOn ? 1 : 0);
        AudioManager.Instance.ToggleSFX(isOn);
    }

    // Apply both toggles’ settings to AudioManager
    private void ApplySettings()
    {
        AudioManager.Instance.ToggleMusic(musicToggle.isOn);
        AudioManager.Instance.ToggleSFX(sfxToggle.isOn);
    }
}
