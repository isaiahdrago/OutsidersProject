using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool GodDone = true;

    public int MaxHP = 100;

    int CurrentHP;

    public float Speed = 7f;

    private Transform Target;

    LayerMask PlayerLayer;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) < 35)
        {
            if (Vector2.Distance(transform.position, Target.position) > 1.29)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(int Damage)
    {
        CurrentHP -= Damage;

        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
