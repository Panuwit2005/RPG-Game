using System.Collections;
using UnityEngine;

public class DoorSwitch : Identity
{
    private bool isOpen = false;                 // สถานะว่าประตูเปิดหรือยัง
    public Vector3 openOffset = new Vector3(2f, 0, 0);  // ระยะที่ประตูจะเลื่อนเวลาเปิด
    public float slideSpeed = 2f;               // ความเร็วตอนเลื่อนประตู
    public Transform door;                      // ตัวประตูที่จะเลื่อน

    private void Awake()
    {
        // ถ้าไม่ได้ตั้งค่า door ใน Inspector ให้ใช้ตัวเองแทน
        if (door == null)
        {
            door = transform;
        }
    }

    // ฟังก์ชันให้สวิตช์เรียกเพื่อเปิดหรือปิดประตู
    public void ToggleDoor()
    {
        Vector3 targetPosition;

        if (isOpen == true)
        {
            targetPosition = door.position - openOffset;
            Debug.Log("🚪 Door Closed");
        }
        else
        {
            targetPosition = door.position + openOffset;
            Debug.Log("🚪 Door Opened");
        }

        StartCoroutine(SlideDoor(targetPosition));
        isOpen = !isOpen;
    }


    // ฟังก์ชันสำหรับเลื่อนประตูแบบนุ่มนวล
    private IEnumerator SlideDoor(Vector3 targetPosition)
    {
        Vector3 startPosition = door.position;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            timeElapsed += Time.deltaTime * slideSpeed;

            // ค่อย ๆ เลื่อนจากตำแหน่งเริ่มต้นไปยังตำแหน่งเป้าหมาย
            door.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed);

            yield return null; // รอเฟรมต่อไป
        }

        // ให้แน่ใจว่าประตูไปถึงตำแหน่งสุดท้ายพอดี
        door.position = targetPosition;
    }
}
