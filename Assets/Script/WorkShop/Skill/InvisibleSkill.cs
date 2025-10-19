using UnityEngine;
using System.Collections;

public class InvisibleSkill : Skill
{
    public float Duration = 5f;
    private Renderer[] playerRenderers;
    private bool isInvisible;

    public ParticleSystem vanishEffect;
    public float vanishDelay = 0.5f;

    public InvisibleSkill()
    {
        this.skillName = "Invisible";
        this.coodddownTime = 10;
        this.DurationSkill = true;
    }

    public override void Activate(Character character)
    {
        character.StartCoroutine(VanishRoutine(character));
    }

    private IEnumerator VanishRoutine(Character character)
    {
        timer = Duration;
        isInvisible = true;

        Player player = character as Player;
        if (player != null) player.isInvisible = true; // ✅ บอก Enemy ว่ามองไม่เห็น

        // เล่น effect ก่อน
        if (vanishEffect != null)
        {
            ParticleSystem effect = GameObject.Instantiate(vanishEffect, character.transform.position, Quaternion.identity);
            effect.Play();
            GameObject.Destroy(effect.gameObject, 2f);
        }

        yield return new WaitForSeconds(vanishDelay);

        // ซ่อนเรนเดอร์
        playerRenderers = character.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in playerRenderers)
        {
            r.enabled = false;
        }

        Debug.Log("Invisible skill activated. Player is hidden!");
    }

    public override void Deactivate(Character character)
    {
        if (!isInvisible) return;
        isInvisible = false;

        Player player = character as Player;
        if (player != null) player.isInvisible = false; // ✅ บอก Enemy ว่ามองเห็นแล้ว

        foreach (Renderer r in playerRenderers)
        {
            if (r != null) r.enabled = true;
        }

        Debug.Log("Invisible skill deactivated. Player is visible again!");
    }

    public override void UpdateSkill(Character character)
    {
        timer -= Time.deltaTime;
        if (timer <= 0) Deactivate(character);
    }
}
