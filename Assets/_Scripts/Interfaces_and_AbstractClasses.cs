using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces_and_AbstractClasses
{
}
public interface IDamageable
{
    void TakeDamage(float damage);
    void ReceiveForce(float force, Vector3 forceDirection);
    Transform ReturnTransform();
}
public enum DamageElement
{
    None, Fire, Water, Nature, Earth, Void, Light, Physical
}

public class Damage : MonoBehaviour
{
    public float _amount;
    public float _addForce;
    public int _tickAmount;
    public float _damageOverTimeDuration;
    public DamageElement _element;

    // Scriptable Object Constructor
    public Damage(DamageInfo damageInfo)   
    {
        _amount = damageInfo.amount;
        _addForce = damageInfo.addForce;
        _tickAmount = damageInfo.tickAmount;
        _damageOverTimeDuration = damageInfo.damageOTDuration;
        _element = damageInfo.element;
    }

    // Fed Values Constructor
    public Damage(float amount, float addForce, DamageElement element = DamageElement.None, int tickNum = 1 , float damageOTDuration = 0)
    {
        _amount = amount;
        _addForce = addForce;
        _tickAmount = tickNum;
        _damageOverTimeDuration = damageOTDuration;
        _element = element;
    }

    public void Hit(IDamageable target, Vector3 forceDirection)
    {
        CombatManager.instance.DealDamage(target,this,forceDirection);
    }
}
