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
        //�̺�Ʈ �߻�
        OnNamekoHarvested?.Invoke(id, transform);

        //��Ȯ
        Destroy(gameObject,0.5f);
    }
}
