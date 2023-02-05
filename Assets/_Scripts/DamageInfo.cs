using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Damage Info")]
public class DamageInfo : ScriptableObject
{
    [SerializeField] public float amount;
    [SerializeField] public float addForce;
    [SerializeField] public DamageElement element;
    [SerializeField] [Min(1)] public int tickAmount;
    [SerializeField] [Min(0)] public float damageOTDuration = 0;
}
