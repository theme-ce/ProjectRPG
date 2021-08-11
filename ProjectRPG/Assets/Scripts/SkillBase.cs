using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Create New Skill")]
public class SkillBase : ScriptableObject
{
    [SerializeField] string skillName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] float dmgBase;
    [SerializeField] float dmgMultiplier;
    [SerializeField] float accuracy;
    [SerializeField] float manaCost;
    [SerializeField] float cooldown;
}
