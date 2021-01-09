using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int ammo;
    

    public int GetAmmo() { return ammo; }

    public void SetAmmo(int a) { ammo = a; }
}
