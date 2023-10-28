using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public static CombatManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Possible multiple instances of CombatManager, destroying extras!");
            Destroy(gameObject);
        }
        else instance = this;
    }

    public void DealDamage(IDamageable target, Damage damage, Vector3 forceDirection)
    {
        StartCoroutine(DealDamageEnum(target, damage, forceDirection));
    }


    public IEnumerator DealDamageEnum(IDamageable target, Damage damage, Vector3 forceDirection)
    {
        float damagePerTick = damage._amount / damage._tickAmount;
        float delayBetweenTicks = damage._damageOverTimeDuration / damage._tickAmount;

        target.TakeDamage(damagePerTick);
        target.ReceiveForce(damage._addForce, forceDirection);

        //Over-Time Damage
        

        for (int i = 0; i < damage._tickAmount -1; i++)
        {
            yield return new WaitForSeconds(delayBetweenTicks);
            target.TakeDamage(damagePerTick);
        }


    }


}
