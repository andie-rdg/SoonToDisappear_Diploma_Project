using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PanelChanging : MonoBehaviour
{

    //..........Panel 0- SCAN the map..........
    public Button SkipButton;
    public GameObject ScanMapPanel;
    public Button DiscoverMemories;

    //..........Panel 1 -SCAN...........
    public Button NextButton;
    public GameObject ScanPanel;

    //..........Panel 2 -DISCOVER..........
    public Button DrawButton;
    public GameObject DiscoverPanel;

    //..........PanelX -Take a moment to reflect..........
    public Button NextDrawButton;
    public GameObject TakeAMomentPanel;


    //...........Panel 3 -DRAWING.......... 
    public Button FinishDrawingButton;
    public GameObject DrawingPanel;

    //..........Panel 4 - STORY..........
    //public Button AddStoryButton;
    public GameObject StoryPanel;
    public Button NextStoryButton;


    //..........Panel 5 - DISPLAY STORY..........
    public GameObject DisplayStoryPanel;
    public Button AddStoryToTheWall;
    

    public ARPlaneManager planeManager;

   

    void Awake()
    {

        //..... for testing purposes i set the ScanPanel to false, but i need to set a begining panel to true after the tests
        ScanPanel.SetActive(false);
        DiscoverPanel.SetActive(false);
        DrawingPanel.SetActive(false);
        StoryPanel.SetActive(false);
        DisplayStoryPanel.SetActive(false);
        TakeAMomentPanel.SetActive(false);

     }
    // Start is called before the first frame update
    void Start()
    {
        NextButton.onClick.AddListener(PlanePrefabOff);
        NextButton.onClick.AddListener(ChangingScanToDiscover);
        DrawButton.onClick.AddListener(ChangingDiscoverToTakeAMoment);
        NextDrawButton.onClick.AddListener(ChangingTakeAMomentToDrawing);
        FinishDrawingButton.onClick.AddListener(ChangingDrawingToStory);
        SkipButton.onClick.AddListener(SkipScanTheMapPanel);
        DiscoverMemories.onClick.AddListener(SkipScanTheMapPanel);
        NextStoryButton.onClick.AddListener(ChangingStoryToAddStory);
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


    void ChangingDiscoverToTakeAMoment()
    {
        DiscoverPanel.SetActive(false);

        Debug.Log("Discover Panel is deactivated");

        TakeAMomentPanel.SetActive(true);

        Debug.Log("TakeAMomentPanel is active");
    }

    void ChangingTakeAMomentToDrawing()
    {
        TakeAMomentPanel.SetActive(false);
        DrawingPanel.SetActive(true);
    }

    void ChangingDrawingToStory()
    {
        DrawingPanel.SetActive(false);

        Debug.Log("Drawing Panel is deactivated");

        StoryPanel.SetActive(true);

        Debug.Log("StoryPanel is active");
    }

    void SkipScanTheMapPanel()
    {
        ScanMapPanel.SetActive(false);
        Debug.Log("ScanTheMapPanel is deactivated");
        ScanPanel.SetActive(true);
        Debug.Log("Scanning Panel is active");
    }

    void ChangingStoryToAddStory()
    {
        StoryPanel.SetActive(false);
        //DisplayStoryPanel.SetActive(true);
        DiscoverPanel.SetActive(true);
    }
}
