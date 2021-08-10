using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCombat : PlayerMovement
{
    public GameObject targetedEnemy;
    public GameObject currentEnemy;
    public GameObject hittingEnemy;

    public float attackRange = 1.5f;

    [Header ("HP and Mana referrences: ")]
    public Slider hpBar;
    public Text hpText;
    public Slider manaBar;
    public Text manaText;

    public bool canAttack = true;

    public GameObject damageText;

    protected override void Update()
    {
        base.Update();

        if(targetedEnemy != currentEnemy)
        {
            currentEnemy = targetedEnemy;
        }
        else
        {
            if (targetedEnemy != null)
            {
                if (Vector2.Distance(this.transform.position, targetedEnemy.transform.position) <= attackRange)
                {
                    moving = false;

                    if(canAttack)
                    {
                        StartCoroutine(BasicAttackInterval(targetedEnemy));
                    }
                }

            }
            else
            {
                canAttack = true;
            }
            SetHpAndManaBar();
        }
    }

    void SetHpAndManaBar()
    {
        hpBar.value = currentHP / maxHP();
        hpText.text = currentHP.ToString();
        manaBar.value = currentMana / maxMana();
        manaText.text = currentMana.ToString();
    }

    IEnumerator BasicAttackInterval(GameObject targetEnemy)
    {
        canAttack = false;
        hittingEnemy = targetedEnemy;
        animator.SetTrigger("Attacking");

        yield return new WaitForSeconds(attackSpeed());

        canAttack = true;
    }

    void MeleeAttack()
    {
        if(targetedEnemy != null)
        {
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().text = attackDmg().ToString();

            Vector3 aboveTarget = new Vector3(hittingEnemy.transform.position.x, hittingEnemy.transform.position.y + 3, 0);
            Instantiate(damageText.transform, aboveTarget, Quaternion.identity);

            hittingEnemy.GetComponent<Enemy>().TakeDamage(attackDmg());
            hittingEnemy = null;
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
    }
}
