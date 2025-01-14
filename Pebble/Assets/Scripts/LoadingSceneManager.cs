using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public float delay = 3f; // Duration of the loading screen in seconds
    public string nextSceneName = "MainSceneAR"; // Name of the main game scene

    public GameObject loadingScreen; // Reference to the loading screen UI
    public UnityEngine.UI.Slider progressBar; // Reference to a UI slider for the progress bar

    void Start()
    {
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true); // Ensure the loading screen is visible
        }
        StartCoroutine(LoadGameAsync());
    }

    private IEnumerator LoadGameAsync()
    {
        yield return new WaitForSeconds(delay / 2); // Optional initial delay

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
        asyncLoad.allowSceneActivation = false; // Prevent the scene from activating immediately

        while (!asyncLoad.isDone)
        {
            // Update progress bar (progress is between 0.0 and 0.9)
            if (progressBar != null)
            {
                progressBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            }

            // When loading is done (progress >= 0.9), activate the scene after delay
            if (asyncLoad.progress >= 0.9f)
            {
                yield return new WaitForSeconds(delay / 2); // Final delay if desired
                asyncLoad.allowSceneActivation = true; // Activate the new scene
            }

            yield return null;
        }
    }
}
