using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipMovement : MonoBehaviour
{
    public Ease ease;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(0, 2).SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
