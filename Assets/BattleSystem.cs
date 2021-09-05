using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, PlayerTurn, EnemyAttack, Win, Lose}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject Player;
    public GameObject Enemy;

    public Transform enemyspawn;

    Unit EnemyUnit;

    public Text DialogueText;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        SetBattle();
    }

    void SetBattle()
    {
        GameObject EnemyGO = Instantiate(Enemy, enemyspawn);
        EnemyUnit = EnemyGO.GetComponent<Unit>();
        DialogueText.text = EnemyUnit.UnitName;
    }
}
