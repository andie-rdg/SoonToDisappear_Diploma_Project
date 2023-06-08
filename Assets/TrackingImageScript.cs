using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class TrackingImageScript : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject prefabImage1; // Reference to the prefab for image 1
    public GameObject prefabImage2; // Reference to the prefab for image 2
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
        prefabImage1.SetActive(false);
        prefabImage2.SetActive(false);
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Check if no prefab is currently instantiated
            if (!prefabImage1.activeSelf && !prefabImage2.activeSelf)
            {
                // Check if the tracked image is Image 1
                if (trackedImage.referenceImage.name == "Image1")
                {
                    //instantiatedPrefab = Instantiate(prefabImage1, trackedImage.transform.position, trackedImage.transform.rotation);
                    prefabImage1.SetActive(true);

                }
                // Check if the tracked image is Image 2
                else if (trackedImage.referenceImage.name == "Image2")
                {
                    prefabImage2.SetActive(true);
                    //instantiatedPrefab = Instantiate(prefabImage2, trackedImage.transform.position, trackedImage.transform.rotation);
                }
            }
        }
    }

    void RemovePrefab()
    {
        if (!prefabImage2.activeSelf)
        {
            Destroy(prefabImage2);

        } else if (!prefabImage1.activeSelf)
            {
                Destroy(prefabImage1);
            }

        }
    }

