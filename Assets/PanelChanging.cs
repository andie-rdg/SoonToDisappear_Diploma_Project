using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PanelChanging : MonoBehaviour
{


    //..........Panel 1 -SCAN...........
    public Button NextButton;
    public GameObject ScanPanel;

    //..........Panel 2 -DISCOVER..........
    public Button DrawButton;
    public GameObject DiscoverPanel;

    //...........Panel 3 -DRAWING.......... 
    public Button FinishDrawingButton;
    public GameObject DrawingPanel;

    //..........Panel 4 - STORY
    //public Button AddStoryButton;
    public GameObject StoryPanel;

    public ARPlaneManager planeManager;

   

    void Awake()
    {
        ScanPanel.SetActive(true);
        DiscoverPanel.SetActive(false);
        DrawingPanel.SetActive(false);
        StoryPanel.SetActive(false);

     }
    // Start is called before the first frame update
    void Start()
    {
        NextButton.onClick.AddListener(PlanePrefabOff);
        NextButton.onClick.AddListener(ChangingScanToDiscover);
        DrawButton.onClick.AddListener(ChangingDiscoverToDrawing);
        FinishDrawingButton.onClick.AddListener(ChangingDrawingToStory);
        //AddStoryButton.onClick.AddListener(UIChanging);
        
        
    }


    void PlanePrefabOff()
    {

        //Find the ARPlaneManager to set its prefab to null;
        GameObject SessionOrigin = GameObject.Find("AR Session Origin");
        planeManager = SessionOrigin.GetComponent<ARPlaneManager>();

        // Assign the custom plane prefab
        planeManager.planePrefab = null;
        
    }


    //..........CHANGING THE UI..........
    void ChangingScanToDiscover()
    {
        ScanPanel.SetActive(false);

        Debug.Log("Scanning Panel is deactivated");

        DiscoverPanel.SetActive(true);

        Debug.Log("DiscoverPanel is active");
    }


    void ChangingDiscoverToDrawing()
    {
        DiscoverPanel.SetActive(false);

        Debug.Log("Discover Panel is deactivated");

        DrawingPanel.SetActive(true);

        Debug.Log("DrawingPanel is active");
    }

    void ChangingDrawingToStory()
    {
        DrawingPanel.SetActive(false);

        Debug.Log("Drawing Panel is deactivated");

        StoryPanel.SetActive(true);

        Debug.Log("StoryPanel is active");
    }
}
