using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_FireballCast : MonoBehaviour
{

    public Transform firePoint;
    public GameObject fireball;

    public void Cast()
    {
        Instantiate(fireball,firePoint.position, Quaternion.LookRotation(transform.forward));
    }
}
