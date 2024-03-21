using UnityEngine;
using System.Collections;

public class FrameController : MonoBehaviour
{
    public float destroyDelay = 15f; // ɾ�����˵��ӳ�ʱ��

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        // ���ӳ�ʱ������ٵ��˶���
        Destroy(gameObject);
    }
}