using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    public float speed = 40f;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Fire()
    {
        //GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
       // spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        animator.SetTrigger("Shoot");
        //Destroy(spawnedBullet, 2f);
    }

}
