using System;
using UnityEngine;

public class HealthEvent : MonoBehaviour
{
    public Action OnHit;
    public Action OnHeal;
    public Action OnDeath;
    public Action OnKick;
}
