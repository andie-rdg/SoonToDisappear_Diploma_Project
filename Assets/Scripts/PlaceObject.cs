using System.Collections; // we are not using it so we could tehcnically delete this line :)
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation; // we need to import that to access the ARRaycastManager
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;


// this script should be on the same Game Object as the aRRaycastManager and aRPlaneManager but to make sure:
// if we attach this script to a gameobject that does not have those 2 components, it will create them for us and we cant delete it either 

[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]

public class PlaceObject : MonoBehaviour
{
    public Button button;
    public Material[] materials;

    [SerializeField] //so we can easily drag it from the inspector

    //it's private because it doesn't need to be accessed by other scripts
    private GameObject prefab;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private int iCurrentMaterial = 0;


    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown; //add function to the liste
        EnhancedTouch.Touch.onFingerMove += FingerMove; //add function to the liste
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown; // we don't want to listen to this event anymore (deletes func from the list)
        EnhancedTouch.Touch.onFingerMove -= FingerMove; // we don't want to listen to this event anymore (deletes func from the list)
    }

    private void Start()
    {
        button.onClick.AddListener(ChangeMaterials);
    }

    private void ChangeMaterials()
    {
        iCurrentMaterial = (iCurrentMaterial + 1) % materials.Length;
        Color col = materials[iCurrentMaterial].color;
        Debug.Log(col);
        ColorBlock cb = button.colors;
        cb.normalColor = col;
        cb.highlightedColor = col;
        cb.pressedColor = col;
        cb.selectedColor = col;
        button.colors = cb;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        FingerDraw(finger);
    }

    private void FingerMove(EnhancedTouch.Finger finger)
    {
        FingerDraw(finger);
    }

    void FingerDraw(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return; // we dont want to support multifinger touch in this case to 2 fingers down will not work

        if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;
                GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
                obj.GetComponent<Renderer>().material = materials[iCurrentMaterial];
            }
        }
    }
}
