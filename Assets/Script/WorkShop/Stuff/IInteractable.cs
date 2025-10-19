using UnityEngine;
using TMPro;
public interface IInteractable
{
    // คุณสมบัติสำหรับชื่อวัตถุ
    // เมธอดที่ต้องมีเพื่อรองรับการโต้ตอบ

    bool IsInteractable { get;set; }
    void Interact(Player player);

}
