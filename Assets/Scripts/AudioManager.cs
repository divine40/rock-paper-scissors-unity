using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip buttonClickSound; // Assign this in the Inspector

    void Awake()
    {
        // Make sure only one AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps AudioManager across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    void Start()
    {
        // Load saved preferences or use defaults (1 = true, 0 = false)
        bool musicOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        bool sfxOn = PlayerPrefs.GetInt("SFXEnabled", 1) == 1;

        ToggleMusic(musicOn);
        ToggleSFX(sfxOn);
    }

    // Toggle Background Music and save preference
    public void ToggleMusic(bool isOn)
    {
        if (musicSource != null)
        {
            musicSource.mute = !isOn;
            PlayerPrefs.SetInt("MusicEnabled", isOn ? 1 : 0);
        }
    }

    // Toggle Sound Effects and save preference
    public void ToggleSFX(bool isOn)
    {
        if (sfxSource != null)
        {
            sfxSource.mute = !isOn;
            PlayerPrefs.SetInt("SFXEnabled", isOn ? 1 : 0);
        }
    }

    // Play Sound Effect
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && !sfxSource.mute && clip != null)
            sfxSource.PlayOneShot(clip);
    }

    // Play Button Click Sound
    public void PlayButtonClick()
    {
        PlaySFX(buttonClickSound);
    }
}
