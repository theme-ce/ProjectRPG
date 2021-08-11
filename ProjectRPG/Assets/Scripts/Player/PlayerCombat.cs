using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCombat : PlayerMovement
{
    public GameObject currentEnemy;

    public float attackRange = 1.5f;

    [Header ("HP and Mana referrences: ")]
    public Slider hpBar;
    public Text hpText;
    public Slider manaBar;
    public Text manaText;

    public bool canAttack = true;

    public GameObject damageText;

    public List<LearnableSkill> learnableSkills;

    protected override void Update()
    {
        base.Update();

        if (targetedEnemy != null)
        {
            if (Vector2.Distance(this.transform.position, targetedEnemy.transform.position) <= attackRange)
            {
                moving = false;

                currentEnemy = targetedEnemy;

                if(canAttack)
                {
                    animator.SetFloat("AttackSpeed", attackSpeed());
                    animator.SetBool("Attacking", true);
                    
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        animator.SetTrigger("FireSword");
                    }

                    else if(Input.GetKeyDown(KeyCode.W))
                    {

                    }
                }
            }
        }
        else
        {
            animator.SetBool("Attacking", false);
        }

        SetHpAndManaBar();
    }

    void SetHpAndManaBar()
    {
        hpBar.value = currentHP / maxHP();
        hpText.text = currentHP.ToString();
        manaBar.value = currentMana / maxMana();
        manaText.text = currentMana.ToString();
    }

    void MeleeAttack()
    {
        if(currentEnemy != null)
        {
            damageText.transform.GetChild(0).GetComponent<TextMeshPro>().text = attackDmg().ToString();

            Vector3 aboveTarget = new Vector3(currentEnemy.transform.position.x, currentEnemy.transform.position.y + 3, 0);
            Instantiate(damageText.transform, aboveTarget, Quaternion.identity);

            currentEnemy.GetComponent<Enemy>().TakeDamage(attackDmg());
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
    }

    [System.Serializable]
    public class LearnableSkill
    {
        public SkillBase skillBase;
        public int level;
}
}
