using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.05f);
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private CanvasGroup fade;
    [SerializeField] private CanvasGroup menu;
    public void LoadFirstlevel()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(FadeToLevel());
    }
    public void Quit()
    {
        Application.Quit();
    }
    private IEnumerator FadeToLevel()
    {
        while (menuMusic.volume != 0.0f)
        {
            fade.alpha += 0.01f;
            menuMusic.volume -= 0.0099f;
            yield return wait;
        }
        SceneManager.LoadSceneAsync(1);
        Destroy(menu.gameObject);
        StartCoroutine(FadeBackFirstLevel());
    }
    private IEnumerator FadeBackFirstLevel()
    {
        while (fade.alpha != 0)
        {
            fade.alpha -= 0.03f;
            yield return wait;
        }
        Destroy(gameObject);
    }
}
