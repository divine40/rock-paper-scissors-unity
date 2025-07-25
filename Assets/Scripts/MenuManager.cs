using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject homePage;
    public GameObject settingsPage;
    public GameObject howToPlayPage;
    public GameObject aboutPage;

    void Start()
    {
        ShowHomePage();  // Only show the home page at start
    }

    public void ShowHomePage()
    {
        homePage.SetActive(true);
        settingsPage.SetActive(false);
        howToPlayPage.SetActive(false);
        aboutPage.SetActive(false);
    }

    public void ShowSettingsPage()
    {
        homePage.SetActive(false);
        settingsPage.SetActive(true);
        howToPlayPage.SetActive(false);
        aboutPage.SetActive(false);
    }

    public void ShowHowToPlayPage()
    {
        homePage.SetActive(false);
        settingsPage.SetActive(false);
        howToPlayPage.SetActive(true);
        aboutPage.SetActive(false);
    }

    public void ShowAboutPage()
    {
        homePage.SetActive(false);
        settingsPage.SetActive(false);
        howToPlayPage.SetActive(false);
        aboutPage.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
