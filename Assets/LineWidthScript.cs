using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineWidthScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Slider slider;

    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateLineWidth);
    }

    private void UpdateLineWidth(float value)
    {
        lineRenderer.startWidth = value;
        lineRenderer.endWidth = value;
    }
}

