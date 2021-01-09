using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractibleTag : XRGrabInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        return base.IsSelectableBy(interactor) && (gameObject.layer == 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
