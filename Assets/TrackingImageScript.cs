using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class TrackingImageScript : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    // References to the prefabs for images
    public GameObject HB; 
    public GameObject Parker;
    public GameObject SJC;
    public GameObject SPX;
    public GameObject kzern;
    public GameObject Memory1;


    public Button closeButton;
    private GameObject instantiatedPrefab = null;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void Start()
    {
        closeButton.onClick.AddListener(RemovePrefab);
        HB.SetActive(false);
        Parker.SetActive(false);
        SJC.SetActive(false);
        SPX.SetActive(false);
        kzern.SetActive(false);
        Memory1.SetActive(false);
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Check if no prefab is currently instantiated
            if (!HB.activeSelf && !Parker.activeSelf && !SJC.activeSelf && !SPX.activeSelf && !kzern.activeSelf)
            {
                // Check if the tracked image is HB
                if (trackedImage.referenceImage.name == "HB")
                {
                    //instantiatedPrefab = Instantiate(prefabImage1, trackedImage.transform.position, trackedImage.transform.rotation);
                    HB.SetActive(true);
                    closeButton.gameObject.SetActive(true);

                }
                // Check if the tracked image is Parker
                else if (trackedImage.referenceImage.name == "Parker")
                {
                    Parker.SetActive(true);
                    closeButton.gameObject.SetActive(true);

                }

                //Check if the tracked image is SJC
                else if (trackedImage.referenceImage.name == "SJC")
                {
                    SJC.SetActive(true);
                    closeButton.gameObject.SetActive(true);

                }

                //Check if the tracked image is SPX
                else if (trackedImage.referenceImage.name == "SPX")
                {
                    SPX.SetActive(true);
                    closeButton.gameObject.SetActive(true);

                }

                //Check if the tracked image is kzern
                else if (trackedImage.referenceImage.name == "kzern")
                {
                    kzern.SetActive(true);
                    closeButton.gameObject.SetActive(true);

                }

                else if (trackedImage.referenceImage.name == "Marker1")
                {
                    Memory1.SetActive(true);
                    Memory1.transform.position = trackedImage.transform.position;
                    closeButton.gameObject.SetActive(true);

                }
            }
        }
    }

    void RemovePrefab()
    {
        if (HB.activeSelf)
        {
            HB.SetActive(false);
            closeButton.gameObject.SetActive(false);

        }
        else if (Parker.activeSelf)
        {
            Parker.SetActive(false);
            closeButton.gameObject.SetActive(false);
        }

        else if (SJC.activeSelf)
        {
            SJC.SetActive(false);
            closeButton.gameObject.SetActive(false);
        }
        else if (SPX.activeSelf)
        {
            SPX.SetActive(false);
            closeButton.gameObject.SetActive(false);
        }
        else if (kzern.activeSelf)
        {
            kzern.SetActive(false);
            closeButton.gameObject.SetActive(false);

        }

    }
    }

