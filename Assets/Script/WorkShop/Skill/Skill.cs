using System;
using UnityEngine;

public abstract class Skill
{
    public string skillName;
    public float coodddownTime;
    public float lastUsedTime = float.MinValue;
    public float timer;
    public bool DurationSkill;

    public abstract void Activate(Character character);
    public abstract void Deactivate(Character character);
    public abstract void UpdateSkill(Character character);

    public bool IsReady(float GameTime)
    {
        return Time.time > lastUsedTime + coodddownTime;
    }  
    public void TimeStampSkill(float GameTime)
    {
        lastUsedTime = GameTime;
    }
    public void DisplayInfo()
    {
        Debug.Log("Skill " + skillName);
        Debug.Log("Cooldown " + coodddownTime);
    }
}
