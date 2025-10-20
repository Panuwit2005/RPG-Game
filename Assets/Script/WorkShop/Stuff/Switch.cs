using System.Collections;
using UnityEngine;

public class Switch : Stuff, IInteractable
{
    public bool isInteractable
    {
        get { return canUse; }
        set { canUse = value; }
    }

    [SerializeField]
    private bool isOn = false;      // สถานะของสวิตช์ เปิดหรือปิด

    [SerializeField]
    private DoorSwitch door;        // เชื่อมกับ DoorSwitch ใน Inspector

    [SerializeField]
    private float cooldownTime = 2f; // เวลา Cooldown หน่วยเป็นวินาที

    private bool isCooldown = false; // ตรวจว่ากำลังคูลดาวน์อยู่ไหม

    private void Awake()
    {
        Name = "Switch";
    }

    public void Interact(Player player)
    {
        // ถ้ากำลังคูลดาวน์อยู่ หรือสวิตช์ใช้งานไม่ได้ ให้ return ทันที
        if (isCooldown == true || isInteractable == false)
        {
            Debug.Log("⏳ Switch is cooling down...");
            return;
        }

        // เริ่มคูลดาวน์
        StartCoroutine(StartCooldown());

        // สลับสถานะของสวิตช์
        if (isOn == false)
        {
            isOn = true;
            Debug.Log("🔘 Switch On");
        }
        else
        {
            isOn = false;
            Debug.Log("🔘 Switch Off");
        }

        // สั่งให้ประตูเปิดหรือปิด (ถ้ามี DoorSwitch เชื่อมไว้)
        if (door != null)
        {
            door.ToggleDoor();
        }
        else
        {
            Debug.LogWarning("❌ ยังไม่ได้ตั้ง DoorSwitch ใน Inspector!");
        }
    }

    private IEnumerator StartCooldown()
    {
        isCooldown = true;
        canUse = false;

        Debug.Log("🕒 Switch cooldown started.");

        // รอเวลาตาม cooldownTime (2 วินาที)
        yield return new WaitForSeconds(cooldownTime);

        isCooldown = false;
        canUse = true;

        Debug.Log("✅ Switch ready to use again.");
    }
}
