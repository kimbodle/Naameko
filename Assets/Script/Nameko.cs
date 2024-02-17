using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Nameko : MonoBehaviour
{
    //��Ȯ�� ����ϵ��� delegate - event ���
    public delegate void NamekoHarvestedDelegate(int id,int Np, Transform transform);
    public static event NamekoHarvestedDelegate OnNamekoHarvested;

    [SerializeField]
    private int id;
    public int Np;

    private void OnMouseDown()
    {
        //��ư UI�� �ƴ� ������Ʈ�̱� ������ OnMouseDown()���
        //�̺�Ʈ �߻�
        OnNamekoHarvested?.Invoke(id, Np, transform);

        //��Ȯ
        GameManager.Instance.HarvestNameko(id);  // ������ ��Ȯ ������ ������Ʈ
        Destroy(gameObject,0.5f);
    }
}
