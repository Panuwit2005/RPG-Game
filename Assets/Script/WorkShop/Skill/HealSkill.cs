using System;
using UnityEngine;

public class HealSkill : Skill
{
    public int HealAmount = 25;
    public HealSkill()
    {
        this.skillName = "Heal";
        this.coodddownTime = 3;
    }
    public override void Activate(Character character)
    {
        Debug.Log("casting " + skillName);
        character.Heal(HealAmount);
    }

    public override void Deactivate(Character character)
    {
        throw new NotImplementedException();
    }

    public override void UpdateSkill(Character character)
    {
        throw new NotImplementedException();
    }
}
