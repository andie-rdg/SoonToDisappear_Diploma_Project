using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class NEXTButton : MonoBehaviour
{

    public Button Next;
    public GameObject panel;
    public ARPlaneManager planeManager;
   


    // Start is called before the first frame update
    void Start()
    {
        Next.onClick.AddListener(PlanePrefabOff);
    }

    // Update is called once per frame
    void PlanePrefabOff()
    {

        GameObject arPlaneManagerGO = GameObject.Find("AR Session Origin");
        planeManager = arPlaneManagerGO.GetComponent<ARPlaneManager>();

        // Assign the custom plane prefab
        planeManager.planePrefab = null;

        panel.SetActive(false);
    }
}
