using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test_EnemyStats : MonoBehaviour, IDamageable
{
    public int maxHp;
    public int currentHp;
    public Material flashMaterial;
    public float flashDuration;
    public GameObject fireball;
    public Transform firepoint;
    public Transform player;
    public float ccResistance;

    private Rigidbody rb;
    private Material originalMaterial;
    public TextMeshProUGUI hpText;
    private SkinnedMeshRenderer meshRenderer;
    private Animator anim;

    public void ReceiveForce(float force, Vector3 forceDirection)
    {
        rb.Sleep();
        rb.WakeUp();
        rb.AddForce(forceDirection * (force * (1-ccResistance)) , ForceMode.Impulse);
    }

    public Transform ReturnTransform()
    {
        return transform;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= (int)damage;
        meshRenderer.material = flashMaterial;
        Invoke("ResetColor", flashDuration);
        if (currentHp <= 0) currentHp = 0;
        hpText.text = currentHp.ToString() + "/" + maxHp.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originalMaterial = meshRenderer.material;
        hpText.text = currentHp.ToString() + "/" + maxHp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        if (Input.GetKeyDown(KeyCode.H))
        {
            TestAttack();
        }
    }

    void ResetColor()
    {
        meshRenderer.material = originalMaterial;
    }

    void TestAttack()
    {

        anim.Play("TestStart");

    }

    void SpawnFireball()
    {
        Instantiate(fireball, firepoint.position, Quaternion.LookRotation( player.position - firepoint.position ));
    }

}

