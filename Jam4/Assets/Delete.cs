using UnityEngine;
using System.Collections;

public class FrameController : MonoBehaviour
{
    public float destroyDelay = 15f; // 删除敌人的延迟时间

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        // 在延迟时间后销毁敌人对象
        Destroy(gameObject);
    }
}