using UnityEngine;

public class Sword : Items
{
    [Header("Sword Settings")]
    [Tooltip("ดาเมจที่เพิ่มให้ผู้เล่นเมื่อถือดาบ")]
    public int damage = 25;

    private bool isEquipped = false;   // กันไม่ให้บวกซ้ำ

    // ใช้เวลาคัดลอกจากอีกเล่ม (ไม่จำเป็นต้องยุ่ง)
    public void InitFrom(Sword source)
    {
        if (source == null) return;
        Name = source.Name;
        damage = source.damage;
    }

    public override void Oncollect(Player mPlayer)
    {
        base.Oncollect(mPlayer);

        if (mPlayer == null || mPlayer.RightHand == null) return;

        // ย้ายดาบไปอยู่ในมือขวา
        transform.SetParent(mPlayer.RightHand, false);
        transform.localPosition = new Vector3(0.09f, -0.03f, 0.03f);
        transform.localRotation = Quaternion.Euler(90f, 0f, 0f);

        // ปิด collider กันชนซ้ำ
        if (_collider != null)
            _collider.enabled = false;

        // ✅ เพิ่มพลังโจมตีให้ผู้เล่น โดยดึงค่าจาก public int damage
        if (!isEquipped)
        {
            mPlayer.Damage += damage;
            isEquipped = true;
        }

        // ✅ เก็บ reference ไว้ใน player เพื่อให้ใช้ toggle ได้ตอนกด J
        mPlayer.sword = gameObject;

        Debug.Log($"{mPlayer.Name} equipped sword: +{damage} Damage (Total {mPlayer.Damage})");
    }

    // ✅ ถ้าอยากให้ถอดดาบแล้วดาเมจลดลง
    public void Unequip(Player mPlayer)
    {
        if (isEquipped && mPlayer != null)
        {
            mPlayer.Damage -= damage;
            isEquipped = false;
            Debug.Log($"{mPlayer.Name} unequipped sword: -{damage} Damage (Total {mPlayer.Damage})");
        }
    }
}
