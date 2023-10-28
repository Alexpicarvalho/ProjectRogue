using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Fireball : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public DamageInfo damageInfo;
    private Damage damage;
    void Start()
    {
        damage = new Damage(damageInfo);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        damage.Hit(collision.collider.GetComponentInParent<IDamageable>(),-collision.GetContact(0).normal);
        Destroy(gameObject);
    }
}
