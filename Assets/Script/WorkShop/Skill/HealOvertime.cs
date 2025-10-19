using UnityEngine;

public class HealOvertime : Skill
{
    public int HealPerTick = 1;
    public float Duration = 5f;
    private float tickTimer = 1f; // เวลานับถอยหลังแต่ละ tick

    public HealOvertime()
    {
        this.skillName = "Heal Over Time";
        this.coodddownTime = 8;
        this.DurationSkill = true; // ✅ เป็น skill แบบมีเวลา
    }

    public override void Activate(Character character)
    {
        timer = Duration;
        tickTimer = 1f;

        Debug.Log("Heal Over Time Activated!");
    }

    public override void Deactivate(Character character)
    {
        Debug.Log("Heal Over Time Ended!");
    }

    public override void UpdateSkill(Character character)
    {
        timer -= Time.deltaTime;
        tickTimer -= Time.deltaTime;

        if (tickTimer <= 0f && timer > 0)
        {
            tickTimer = 1f; // reset tick
            character.Heal(HealPerTick);

            Debug.Log(character.Name + " healed +" + HealPerTick + " HP. Current HP: " + character.Health + "/" + character.maxHealth);
        }

        if (timer <= 0)
        {
            Deactivate(character);
        }
    }
}
