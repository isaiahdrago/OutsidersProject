using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float speed = 5f;

    private float move;

    public Transform PunchPoint;

    public float AttackRange = 0.5f;

    public LayerMask EnemyLayer;

    public int AttackDMG = 40;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (move < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            move = -1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            move = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Punch();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Punch()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PunchPoint.position, AttackRange, EnemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(AttackDMG);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (PunchPoint == null)
            return;

        Gizmos.DrawWireSphere(PunchPoint.position, AttackRange);
    }
}
