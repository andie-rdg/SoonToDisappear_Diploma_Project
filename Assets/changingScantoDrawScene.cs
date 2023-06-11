using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changingScantoDrawScene : MonoBehaviour
{


    public Button SkipButton;
    public Button DiscoverButton;
    public string sceneToDownload;

    void Start()
    {
        SkipButton.onClick.AddListener(ChangeScene);
        DiscoverButton.onClick.AddListener(ChangeScene);   
    }


    void ChangeScene()
    {
         SceneManager.LoadScene(sceneToDownload);
    }
}
