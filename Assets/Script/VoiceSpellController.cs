using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class VoiceSpellController : MonoBehaviour
{
    public Player player;
    public SkillBook skillBook; // ✅ ใส่ reference ของ SkillBook

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> commands = new Dictionary<string, System.Action>();

    public GameObject NukeClear;

    void Start()
    {
        if (skillBook == null)
        {
            Debug.LogError("SkillBook reference is missing!");
            return;
        }

        // 🔹 ผูกคำสั่งเสียง
        commands.Add("Fire Ball", CastFireball);
        commands.Add("Heal", CastHeal);
        commands.Add("Speed Up", CastSpeedBoost);
        commands.Add("Invisible", CastInvisible);
        commands.Add("Heal Over Time", CastHealOverTime);
        commands.Add("Attack", CastAttack);
        commands.Add("Golden Flower", CastAllahuAkbar);

        keywordRecognizer = new KeywordRecognizer(commands.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Recognized: " + args.text);
        if (commands.ContainsKey(args.text))
        {
            commands[args.text].Invoke();
        }
    }

    // -------------------- ใช้สกิลจาก SkillBook --------------------
    void CastFireball() => UseSkillByIndex(0);
    void CastHeal() => UseSkillByIndex(1);
    void CastSpeedBoost() => UseSkillByIndex(2);
    void CastInvisible() => UseSkillByIndex(3);
    void CastHealOverTime() => UseSkillByIndex(4);

    void UseSkillByIndex(int index)
    {
        if (skillBook.skillsSet == null || index >= skillBook.skillsSet.Count) return;

        Skill skill = skillBook.skillsSet[index];
        if (!skill.IsReady(Time.time))
        {
            Debug.Log("Skill is cooldown");
            return;
        }

        // ✅ เล่น Effect ถ้ามี
        if (skillBook.skillEffects != null && index < skillBook.skillEffects.Length && skillBook.skillEffects[index] != null)
        {
            GameObject g = Instantiate(skillBook.skillEffects[index], player.transform.position, Quaternion.identity, player.transform);
            Destroy(g, 1f);
        }

        skill.Activate(player);
        skill.TimeStampSkill(Time.time);
    }

    void CastAttack()
    {
        player.Attack(true);
    }

    void CastAllahuAkbar()
    {
        Destroy(NukeClear);
    }

    void OnDestroy()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
            keywordRecognizer.Stop();
    }

    void Update()
    {
        // ✅ อัปเดตสกิล Duration
        if (skillBook == null) return;
        for (int i = skillBook.DurationSkills.Count - 1; i >= 0; i--)
        {
            skillBook.DurationSkills[i].UpdateSkill(player);
            if (skillBook.DurationSkills[i].timer <= 0)
                skillBook.DurationSkills.RemoveAt(i);
        }
    }
}
