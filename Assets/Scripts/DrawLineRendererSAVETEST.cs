using System.Collections; // we are not using it so we could tehcnically delete this line :)
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation; // we need to import that to access the ARRaycastManager
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using TMPro;



[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]


public class DrawLineRendererSAVETEST : MonoBehaviour

{

    public TMP_Text Text;
    public TMP_Text Text2;
    public TMP_Text Text3;
    public Button ColorButton;
    public Button EraseButton;


    public Material[] materials;
    public GameObject parent;


    [SerializeField] 
    private GameObject prefab;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private int iCurrentMaterial = 0;


    public List<LineRenderer> allLineRenderers = new List<LineRenderer>();

    LineRenderer lr;
    LineRenderer lr2;
    public Slider slider;
    float lineWidth = 0.04f;

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
        ColorButton.onClick.AddListener(ChangeMaterials);
        slider.onValueChanged.AddListener(UpdateLineWidth);

        EraseButton.onClick.AddListener(Erase);

    }

    void Update()
    {
       
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
        lineWidth = Mathf.Lerp(0.01f, 0.08f, value);
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


            }
        }
        //test with retrieving linerenderer's positions
        RetrieveLineRendererPositions();
    }


    void RetrieveLineRendererPositions()
    {
        foreach (LineRenderer lr in allLineRenderers)
        {
            Vector3 InitialPosition = Vector3.zero;

            GameObject obj = Instantiate(prefab, InitialPosition, Quaternion.identity);
            lr2 = obj.GetComponent<LineRenderer>();


            int positionCount = lr.positionCount;

            for (int i = 0; i < positionCount; i++)
            {
                Vector3 position = lr.GetPosition(i);
                // Do something with the position
                Text.text = "Line Renderer " + lr.name + ", Position " + i + ": " + position;

                lr2.SetPosition(i, position);

            }
        }
        Text2.text = "count:" + allLineRenderers.Count;
    }


    void Erase()
    {
        Debug.Log("erase function");

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

        Text.text = "count:" + allLineRenderers.Count;

    }
}