using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestStats : MonoBehaviour, IDamageable
{

    [SerializeField] public int MaxHP;
    int HP;
    [SerializeField] DamageInfo testDamageInfo;
    Damage testDamage;
    [SerializeField] TextMeshProUGUI hpTest;
    Rigidbody rb;

    public void ReceiveForce(float force, Vector3 forceDirection)
    {
        rb.Sleep();
        rb.WakeUp();
        rb.AddForce(forceDirection * force, ForceMode.Impulse);
        Debug.Log("Pushed");
    }

    public Transform ReturnTransform(){ return this.transform; }

    public void TakeDamage(float damage)
    {
        HP -= (int)damage;
        if(HP <= 0) HP = 0;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        testDamage = new Damage(testDamageInfo);
        HP = MaxHP;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            testDamage.Hit(this, -transform.forward);
        }
        hpTest.text = HP.ToString() + " / " + MaxHP.ToString();

    }
}
