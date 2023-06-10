using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour
{
    public float delay = 3.0f; // Delay in seconds before changing the scene
    public float fadeDuration = 1.0f; // The duration of the fade effect

    private CanvasGroup canvasGroup;

    private void Start()
    {
        Invoke("ChangeScene", delay);
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;

        // Start the fade-in effect
        StartCoroutine(FadeToBlack());
    }




    private System.Collections.IEnumerator FadeToBlack()
    {
        float timer = 0f;
        float startAlpha = canvasGroup.alpha;
        float endAlpha = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeDuration);
            canvasGroup.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Set the final alpha value to 1
        canvasGroup.alpha = endAlpha;

        // Fade-to-black effect completed
        Debug.Log("Fade-to-black complete");
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("[3]-ScanningDrawingText"); // Replace "YourSceneName" with the name or index of your desired scene
    }

}
