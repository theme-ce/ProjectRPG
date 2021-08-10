using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : EnemyBase
{
    public GameObject enemyUI;
    public Slider hpBar;
    public Text hpText;
    public Player player;

    protected virtual void Update()
    {
        SetHpBar();
        Death();
    }

    public void TakeDamage(float dmgTaken)
    {
        currentHP -= dmgTaken;
    }

    void SetHpBar()
    {
        if(player.GetComponent<PlayerCombat>().targetedEnemy == null)
        {
            enemyUI.SetActive(false);
        }

        if(player.GetComponent<PlayerCombat>().targetedEnemy == this.gameObject)
        {
            enemyUI.SetActive(true);
            hpBar.value = currentHP / maxHP;
            hpText.text = currentHP.ToString();
        }
    }

    void Death()
    {
        if (currentHP <= 0)
        {
            player.GetComponent<PlayerCombat>().targetedEnemy = null;
            enemyUI.SetActive(false);

            player.GetComponent<PlayerBase>().currentEXP += expDrop;
            player.GetComponent<PlayerBase>().gold += goldDrop;

            Destroy(this.gameObject);
        }
    }
}
