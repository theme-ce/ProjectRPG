using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] protected Animator animator;

    [Header("Status Setting: ")]
    public float currentHP;
    public float currentMana;

    public int stat_str = 0;
    public int stat_agi = 0;
    public int stat_int = 0;
    public int stat_vit = 0;
    public int stat_dex = 0;

    [Header("Level & Gold: ")]
    public int level;
    public int currentEXP = 0;
    public int maxEXP;
    public int gold = 0;

    public GameObject targetedEnemy;

    protected virtual void Start()
    {
        currentHP = maxHP();
        currentMana = maxMana();
    }

    public float attackDmg()
    {
        return Mathf.Floor(Random.Range(9.5f, 10f) * stat_str);
    }

    public float attackSpeed()
    {
        return 0.05f * stat_agi;
    }

    public float maxHP()
    {
        return 50 * stat_vit;
    }

    public float maxMana()
    {
        return 20 * stat_int;
    }
}
