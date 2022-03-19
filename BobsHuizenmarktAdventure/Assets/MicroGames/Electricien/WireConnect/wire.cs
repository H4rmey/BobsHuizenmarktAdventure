using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    public float width;
    public Color color;

    public Transform start;
    public Transform end;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Update()
    {
        if (start != null)
            CreateCylinderBetweenPoints(start.position, end.position, width);
    }

    void CreateCylinderBetweenPoints(Vector3 start, Vector3 end, float width)
    {
        var offset = end - start;
        var scale = new Vector3(width, offset.magnitude / 2.0f, width);
        var position = start + (offset / 2.0f);

        transform.position = position;
        transform.up = offset;
        transform.localScale = scale;
    }
}
