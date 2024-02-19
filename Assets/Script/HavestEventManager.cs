using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavestEventManager : MonoBehaviour
{
    //��Ȯ�� ����ϵ��� delegate - event ���
    public delegate void NamekoHarvestedDelegate(int id, int Np, Transform transform);
    public static event NamekoHarvestedDelegate OnNamekoHarvested;

    public static void HarvestNameko(int id, int Np, Transform transform)
    {
        OnNamekoHarvested?.Invoke(id, Np, transform);
    }
}
