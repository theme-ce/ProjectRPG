using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCombat : PlayerMovement
{

    [Header ("HP and Mana referrences: ")]
    public Slider hpBar;
    public Text hpText;
    public Slider manaBar;
    public Text manaText;

    [Header ("Combar & Skill: ")]
    public float attackRange = 1.5f;
    public bool canAttack = true;

    [Space]
    public bool canFireSword = true;
    public FireSwordSkill fireSwordSkill;


    protected override void Update()
    {
        base.Update();

        CombatAction();
        SetHpAndManaBar();
    }

    void CombatAction()
    {
        if (targetedEnemy != null)
        {
            if (Vector2.Distance(this.transform.position, targetedEnemy.transform.position) <= attackRange)
            {
                moving = false;

                currentEnemy = targetedEnemy;

                if (canAttack)
                {
                    animator.SetFloat("AttackSpeed", attackSpeed());
                    animator.SetBool("Attacking", true);

                    if (Input.GetKeyDown(KeyCode.Q) && canFireSword)
                    {
                        Debug.Log("Use Fire Sword!");
                        StartCoroutine(UseFireSword());
                        
                    }

                    else if (Input.GetKeyDown(KeyCode.W))
                    {

                    }
                }
            }
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
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

    void FireSwordAttack()
    {
        float fireSwordDamage = Mathf.Floor(attackDmg() * fireSwordSkill.dmgMultiplier);
        damageText.transform.GetChild(0).GetComponent<TextMeshPro>().text = fireSwordDamage.ToString();

        Vector3 aboveTarget = new Vector3(currentEnemy.transform.position.x, currentEnemy.transform.position.y + 3, 0);
        Instantiate(damageText.transform, aboveTarget, Quaternion.identity);

        currentEnemy.GetComponent<Enemy>().TakeDamage(fireSwordDamage);
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
    }

    IEnumerator UseFireSword()
    {
        canFireSword = false;
        animator.SetTrigger("FireSword");

        yield return new WaitForSeconds(fireSwordSkill.cooldown);

        canFireSword = true;
    }
}
