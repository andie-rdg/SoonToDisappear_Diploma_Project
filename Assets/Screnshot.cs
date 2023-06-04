using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screnshot : MonoBehaviour
{

    public Canvas canvas;
    public Button ScreenshotButton;
    // Start is called before the first frame update
    void Start()
    {
        ScreenshotButton.onClick.AddListener(ScreenshotFunction);
    }

    // Update is called once per frame
    void ScreenshotFunction()
    {
        canvas.enabled = !canvas.enabled;
    }
}
