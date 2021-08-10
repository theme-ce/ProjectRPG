using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public float maxMana;
    public float currentMana;

    public int level;
    public int expDrop;
    public int goldDrop;
}
