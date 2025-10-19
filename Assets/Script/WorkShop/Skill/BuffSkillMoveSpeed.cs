using System;
using UnityEngine;

public class BuffSkillMoveSpeed : Skill
{
    float SpeedIncreaseAmount = 5f;
    float OriginalSpeed;
    float TargetSpeed;
    public float Durarion;

    public BuffSkillMoveSpeed()
    {
        this.skillName = "Speed Boost";
        this.coodddownTime = 5;
        this.Durarion = 3;
        this.DurationSkill = true; // ✅ บอก SkillBook ว่านี่คือสกิลแบบมีระยะเวลา
    }

    public override void Activate(Character character)
    {
        timer = Durarion;
        OriginalSpeed = character.movementSpeed;
        TargetSpeed = OriginalSpeed + SpeedIncreaseAmount;

        // ✅ apply effect ทันที ไม่ต้องรอ UpdateSkill
        character.movementSpeed = TargetSpeed;

        Debug.Log(skillName + " is Activate. New speed: " + character.movementSpeed);
    }

    public override void Deactivate(Character character)
    {
        character.movementSpeed = OriginalSpeed;
        Debug.Log(skillName + " is Deactivate. Speed back to: " + character.movementSpeed);
    }

    public override void UpdateSkill(Character character)
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Deactivate(character);
        }
    }
}
