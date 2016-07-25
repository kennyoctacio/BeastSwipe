using UnityEngine;
using System.Collections;
using System;

public class OrderSpectrumHex : Hexagon {
    
    public void Start()
    {
        SetColor(new Color(1f, 0.8f, 0.5f, 0.9f));
    }

    public override Vector3 GetCellDimensions()
    {
        var ret = GetComponent<SpriteRenderer>().bounds.size;
        return ret * 1.07f;
    }

    public override void MarkAsHighlighted()
    {
        SetColor(new Color(1f, 0.8f, 0.9f, 0.9f));
    }

    public override void MarkAsPath()
    {
        SetColor(Color.green);
    }

    public override void MarkAsReachable()
    {
        SetColor(Color.white);
    }

    public override void UnMark()
    {
        SetColor(new Color(1f, 0.8f, 0.5f, 0.9f));
    }

    public void SetColor(Color color)
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.color = color;
    }

}
