using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    WaitForSecondsRealtime wait;
    private void Start()
    {
        wait = new WaitForSecondsRealtime(7);
        StartCoroutine(LoadMainMenu());
    }
    private void Update()
    {
        if (Input.anyKey)
            SceneManager.LoadScene(0);
    }
    private IEnumerator LoadMainMenu()
    {
        yield return wait;
        SceneManager.LoadScene(0);
    }
}
