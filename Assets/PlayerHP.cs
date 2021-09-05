using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int MaxHP = 80;

    private int CurrentHP;

    void Start()
    {
        CurrentHP = MaxHP;
    }

    public void DamagePlayer(int Damage)
    {
        CurrentHP -= Damage;
        if (CurrentHP <= 0)
            Die();
    }

    void Die() 
    {
        
    }
}
