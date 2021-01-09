using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorTag : XRSocketInteractor { 


    public string targetTag;
   


    public override bool CanSelect(XRBaseInteractable i)
    {
        return base.CanSelect(i) && i.CompareTag(targetTag);
    }

    private void Update()
    {
        //if (selectTarget != null)
        //{
        //    selectTarget.transform.position = GameObject.Find("omae").transform.position;
        //}
    }

}
