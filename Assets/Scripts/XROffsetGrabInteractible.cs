using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XROffsetGrabInteractible : XRGrabInteractable
{
    private Vector3 initialAttatchLocalPos;
    private Quaternion initialAttatchLocalRot;
    private void Start()
    {
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }
        initialAttatchLocalPos = attachTransform.localPosition;
        initialAttatchLocalRot = attachTransform.localRotation;
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if(interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }else
        {
            attachTransform.localPosition = initialAttatchLocalPos;
            attachTransform.localRotation = initialAttatchLocalRot;
        }
        base.OnSelectEntered(interactor);
    }
}
