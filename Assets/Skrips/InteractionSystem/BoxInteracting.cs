using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteracting : Interaction
{
    private DistanceJoint2D _distanceJoint2D;

    private void Start()
    {
        _distanceJoint2D = GetComponent<DistanceJoint2D>();   
    }

    public override void Interact()
    {
        Grab();
    }

    private void Grab()
    {
        _distanceJoint2D.enabled = !_distanceJoint2D.enabled;
    }

    public void CancelObjectCapture()
    {
        _distanceJoint2D.enabled = false;
    }
}
