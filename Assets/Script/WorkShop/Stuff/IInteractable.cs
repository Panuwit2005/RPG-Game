using UnityEngine;
using TMPro;
public interface IInteractable
{
    // �س���ѵ�����Ѻ�����ѵ��
    // ���ʹ����ͧ�������ͧ�Ѻ�����ͺ

    bool isInteractable { get;set; }
    void Interact(Player player);

}
