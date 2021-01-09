using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class MagazineControl : MonoBehaviour
{

    private GameObject currentMagzine;
    private Pistol pistol;

    // Start is called before the first frame update
    void Start()
    {
        pistol = GameObject.Find("Glock Pistol").GetComponent<Pistol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMagzine == null) return;
        if (currentMagzine.transform.rotation == gameObject.transform.rotation) return;
 
        currentMagzine.transform.rotation = gameObject.transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PistolMagazine"))
        {
            currentMagzine = other.gameObject;
            currentMagzine.transform.SetParent(gameObject.transform);
            currentMagzine.transform.position = gameObject.transform.position;
            currentMagzine.GetComponent<Rigidbody>().isKinematic = true;
            currentMagzine.layer = 12;
            pistol.AddNewMagazine(currentMagzine.GetComponent<Magazine>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PistolMagazine"))
        {
            currentMagzine.transform.SetParent(null);
            currentMagzine.GetComponent<Rigidbody>().isKinematic = false;
            currentMagzine.layer = 8;
            currentMagzine = null;
            pistol.RemoveMagazine();
        }
    }
}
