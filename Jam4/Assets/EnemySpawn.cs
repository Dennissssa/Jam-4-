using UnityEngine;

public class ObjectHider : MonoBehaviour
{
    private Collider[] colliders; // 物体的碰撞器数组
    public float showDelay = 30f; // 显示物体的延迟时间

    private void Start()
    {
        // 获取物体的所有碰撞器
        colliders = GetComponentsInChildren<Collider>();

        // 隐藏物体并禁用碰撞检测
        HideObject();
        DisableCollisions();

        // 延迟显示物体并启用碰撞检测
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
