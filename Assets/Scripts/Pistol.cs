using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    public float range = 40f;
    public Transform gunPoint;
    public GameObject bulletCartridge;
    public Transform bulletEjectPoint;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public LayerMask gunHitLayer;


    private int numberOfAmmo = 10;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.DrawRay(gunPoint.position, gunPoint.forward * range, Color.green);

    }
    public void PullTrigger()
    {
        if (numberOfAmmo <= 0) return;
        animator.SetTrigger("Shoot");
        numberOfAmmo--;

    }

    public void ShootBullet()
    {
        audioSource.PlayOneShot(audioClip);
        RaycastHit hit;
        if (Physics.Raycast(gunPoint.position, gunPoint.forward, out hit, range, gunHitLayer))
        {
            if (hit.collider.tag == "Ball") Destroy(hit.collider.gameObject);
        }
    }

    public void EjectCartridge()
    {
        GameObject tempCartridge = Instantiate(bulletCartridge, bulletEjectPoint.position, bulletEjectPoint.rotation) as GameObject;
        tempCartridge.GetComponent<Rigidbody>().AddForce(bulletEjectPoint.right * -1 * Random.Range(100f, 150f) + bulletEjectPoint.forward * -1 * Random.Range(100f, 150f));
        tempCartridge.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);
        Destroy(tempCartridge, 5f);
    }

}
