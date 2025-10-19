using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : Skill
{
    public int Damage = 50;
    public float Range = 5f;

    public FireballSkill()
    {
        this.skillName = "Fireball Skill";
        this.coodddownTime = 5;
    }

    public override void Activate(Character character)
    {
        Debug.Log("Casting " + skillName + " dealing damage " + Damage);

        Enemy[] targets = GetEnemysInRange(character);

        if (targets.Length > 0)
        {
            foreach (Enemy enemy in targets)
            {
                enemy.TakeDamage(Damage);

                // 🔹 แก้ตรงนี้ จาก enemy.health → enemy.GetComponent<Character>().health
                Debug.Log(enemy.Name + " took " + Damage + " damage. HP: " +
                          enemy.GetComponent<Character>().Health + "/" +
                          enemy.GetComponent<Character>().maxHealth);
            }
        }
        else
        {
            Debug.Log("No target in range");
        }
    }

    public override void Deactivate(Character character) { }
    public override void UpdateSkill(Character character) { }

    private Enemy[] GetEnemysInRange(Character caster)
    {
        Collider[] hitColliders = Physics.OverlapSphere(caster.transform.position, Range);
        List<Enemy> enemies = new List<Enemy>();

        foreach (var hitCollider in hitColliders)
        {
            Enemy targetCharacter = hitCollider.GetComponent<Enemy>();
            if (targetCharacter != null && targetCharacter != caster)
            {
                enemies.Add(targetCharacter);
            }
        }
        return enemies.ToArray();
    }
}
