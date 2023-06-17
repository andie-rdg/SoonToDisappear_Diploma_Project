using System.Collections; // we are not using it so we could tehcnically delete this line :)
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation; // we need to import that to access the ARRaycastManager
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using TMPro;


// this script should be on the same Game Object as the aRRaycastManager and aRPlaneManager but to make sure:
// if we attach this script to a gameobject that does not have those 2 components, it will create them for us and we cant delete it either 

[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]

//---- i added a RequireComponent MESH
// [RequireComponent(typeof(MeshCollider))]

public class DrawLineRendererSaveLoad : MonoBehaviour

{

    public Button Draw;
    public Button FinishDrawing;
    public Button ColorButton;
    public Button EraseButton;
    //public Button finish;
    public Material[] materials;
    public GameObject parent;
    //public GameObject inputStory;
    //public GameObject okButton;

    [SerializeField] //so we can easily drag it from the inspector --  it's just valable pour le suivant :)

    //it's private because it doesn't need to be accessed by other scripts
    private GameObject prefab;
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private int iCurrentMaterial = 0;


    public List<LineRenderer> allLineRenderers = new List<LineRenderer>();

    LineRenderer lr; //variable lr type Line Renderer
    public Slider slider;
    float lineWidth = 0.01f;

    //déclaration mesh collider
    //private MeshCollider lineCollider;

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        //lr.positionCount = 0; //setting the number of positions to 0
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        //add function to the liste


    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        

    }

    private void Start()
    {

        Draw.onClick.AddListener(EnableDrawing);
        FinishDrawing.onClick.AddListener(DisableDrawing);
        ColorButton.onClick.AddListener(ChangeMaterials);
        slider.onValueChanged.AddListener(UpdateLineWidth);

        EraseButton.onClick.AddListener(Erase);


        // if we click on "finish" it will create a mesh collider for the lineRenderer and show an input field
        //finish.onClick.AddListener(WriteStory);

        //inputStory.SetActive(false);
        //okButton.SetActive(false);

    }

    private void EnableDrawing (){
        EnhancedTouch.Touch.onFingerDown += FingerDown; //add function to the liste
        EnhancedTouch.Touch.onFingerMove += FingerMove;
    }


    private void DisableDrawing()
    {
        EnhancedTouch.Touch.onFingerDown -= FingerDown; // we don't want to listen to this event anymore (deletes func from the list)
        EnhancedTouch.Touch.onFingerMove -= FingerMove; // we don't want to listen to this event anymore (deletes func from the list)
    }

    private void ChangeMaterials()
    {
        iCurrentMaterial = (iCurrentMaterial + 1) % materials.Length;
        Color col = materials[iCurrentMaterial].color;
        Debug.Log(col);
        ColorBlock cb = ColorButton.colors;
        cb.normalColor = col;
        cb.highlightedColor = col;
        cb.pressedColor = col;
        cb.selectedColor = col;
        ColorButton.colors = cb;
    }

    private void UpdateLineWidth(float value)
    {
        lineWidth = Mathf.Lerp(0.01f, 0.2f, value);
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        // Redémarre un nouveau line renderer
        lr = null;

        addPoint(finger);

        //if (finger.index != 0) return; // we dont want to support multifinger touch in this case to 2 fingers down will not work

        ////this can be another function:

        //if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        //{
        //    foreach(ARRaycastHit hit in hits)
        //    {

        //        Pose pose = hit.pose;
        //        GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
        //        lr = obj.GetComponent<LineRenderer>();
        //        lr.positionCount = 1; // je veux 1 point
        //        lr.SetPosition(lr.positionCount - 1, pose.position); //on rajoute a l'indext positionCount-1 (car ça commence à 1, la position (VECTOR3)

        //    }
        //}
    }

    private void FingerMove(EnhancedTouch.Finger finger)
    {
        addPoint(finger);
        //if (finger.index != 0) return; // we dont want to support multifinger touch in this case to 2 fingers down will not work

        ////this can be another function:

        //if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        //{
        //    foreach (ARRaycastHit hit in hits)
        //    {
        //        lr.positionCount++; // on rajoute un point
        //        Pose pose = hit.pose;
        //        lr.GetComponent<Renderer>().material = materials[iCurrentMaterial];
        //        lr.SetPosition(lr.positionCount - 1, pose.position);
        //        //Debug.Log(pose.position);
        //        //Debug.Log(lr.transform);

        //    }
        //}
    }

    void addPoint(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return; // we dont want to support multifinger touch in this case to 2 fingers down will not work

        //this can be another function:

        if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;

                if (lr == null)
                {
              
                    GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
                    obj.transform.parent = GameObject.Find("Drawing").transform;
                    lr = obj.GetComponent<LineRenderer>();
                    lr.positionCount = 0;
                    lr.material = materials[iCurrentMaterial];
                    lr.startWidth = lineWidth;
                    lr.endWidth = lineWidth;


                    //we are adding our created lr to the list "allLineRenderers"
                    allLineRenderers.Add(lr);

                }

                

                lr.positionCount++; // on rajoute un point
                lr.SetPosition(lr.positionCount - 1, pose.position);
                //Debug.Log(pose.position);
                //Debug.Log(lr.transform);

            }
        }
        //test with retrieving linerenderer's positions
       // RetrieveLineRendererPositions();
    }

    //void SaveToJson()
    //{
        // Application.persistantDataPath is a repo created by unity & doesn't delete even when app is updated
        //string filePath = Application.persistentDataPath + "/dataInventaire.json";
        // Get all the positions of the Line Renderer
        //int positionCount = lr.positionCount;

      
    //}

    

    //void RetrieveLineRendererPositions()
   // {
       // foreach (LineRenderer lr in allLineRenderers)
       // {
          //  int positionCount = lr.positionCount;
          //  for (int i = 0; i < positionCount; i++)
           // {
              //  Vector3 position = lr.GetPosition(i);
               // // Do something with the position
               // //Text.text= "Line Renderer " + lr.name + ", Position " + i + ": " + position;
           // }
       // }
   // }


    void Erase()
    {
        //Debug.Log("erase function");

        // access the last child of the list

        LineRenderer lastChild = allLineRenderers[allLineRenderers.Count - 1];


        // Get the last child's Transform component
        //Transform lastChildTransform = transform.GetChild(transform.childCount - 1);

        // Get the last child's game object
        // GameObject lastChildObject = lastChildTransform.gameObject;
        //if (transform.childCount > 0)
         if(allLineRenderers.Count > 0)
        {

            // Destroy the last child object
            // Destroy(lastChildObject);
            allLineRenderers.RemoveAt(allLineRenderers.Count - 1);
            //Destroy the last lr child that is insite LineRenderersList
            Destroy(lastChild);
        }

        //Text.text = "count:" + allLineRenderers.Count;

    }


   
}