using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Nameko : MonoBehaviour
{
    //��Ȯ�� ����ϵ��� delegate - event ���
    public delegate void NamekoHarvestedDelegate(int id, Transform transform);
    public static event NamekoHarvestedDelegate OnNamekoHarvested;

    public int id;

    private void OnMouseDown()
    {
        //��ư UI�� �ƴ� ������Ʈ�̱� ������ OnMouseDown()���
        //�̺�Ʈ �߻�
        OnNamekoHarvested?.Invoke(id, transform);

        //��Ȯ
        GameManager.Instance.HarvestNameko(id);  // ������ ��Ȯ ������ ������Ʈ
        Destroy(gameObject,0.5f);
    }
}
