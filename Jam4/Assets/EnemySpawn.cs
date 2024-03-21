using UnityEngine;

public class ObjectHider : MonoBehaviour
{
    private Collider[] colliders; // �������ײ������
    public float showDelay = 30f; // ��ʾ������ӳ�ʱ��

    private void Start()
    {
        // ��ȡ�����������ײ��
        colliders = GetComponentsInChildren<Collider>();

        // �������岢������ײ���
        HideObject();
        DisableCollisions();

        // �ӳ���ʾ���岢������ײ���
        Invoke("ShowObject", showDelay);
        Invoke("EnableCollisions", showDelay);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    private void ShowObject()
    {
        gameObject.SetActive(true);
    }

    private void DisableCollisions()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }

    private void EnableCollisions()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
}
