using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WitheredNameko : MonoBehaviour
{
    //��Ȯ�� ����ϵ��� delegate - event ���
    public delegate void NamekoHarvestedDelegate(int id, int Np, Transform transform);
    public static event NamekoHarvestedDelegate OnNamekoHarvested;

    private Animator animator;

    [SerializeField]
    private int id;
    public int Np;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("isHavesting");
        //��Ȯ
        GameManager.Instance.HarvestNameko(id, Np);  // ������ ��Ȯ ������ ������Ʈ

        //��ư UI�� �ƴ� ������Ʈ�̱� ������ OnMouseDown()���
        //�̺�Ʈ �߻�
        OnNamekoHarvested?.Invoke(id, Np, transform);

        Destroy(gameObject, 1.5f);
    }
}
