using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{
    public Camera cam;

    Coroutine drawing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            FinishLine();
        }

    }

    void StartLine()
    {
        Debug.Log("StartLine", this);
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
    }

    void FinishLine()
    {
        Debug.Log("FinishLine");

        StopCoroutine(drawing);
    }

    IEnumerator DrawLine()
    {

        //GameObject prevLine = 

        GameObject lineObject = Instantiate(Resources.Load("Line") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while (true)
        {
            //Debug.Log(cam);
            if (cam)
            {
                Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
                position.z = 1;
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, position);
            }
            yield return null;
        }
    }
}