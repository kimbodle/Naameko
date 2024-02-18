using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slTimer;
    //private bool is1Time = false;

    public ItemManager itemManager;

    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemManager.is1)
        {
            // 60�� ���� value�� 100���� 0���� �����ϵ��� �ӵ��� ����
            slTimer.value -= Time.deltaTime * (slTimer.maxValue / 60f);

            // value�� 0�̸� is1�� false�� ����
            if (slTimer.value <= 0)
            {
                itemManager.SpawnOk = false;
                Debug.Log("1�г�");
            }
        }
        else if (itemManager.is15)
        {
            // 60�� ���� value�� 100���� 0���� �����ϵ��� �ӵ��� ����
            slTimer.value -= Time.deltaTime * (slTimer.maxValue / 600f);

            // value�� 0�̸� is1�� false�� ����
            if (slTimer.value <= 0)
            {
                itemManager.SpawnOk = false;
                Debug.Log("15�� ��");
            }
        }
        else
        {
            Debug.Log("�ð� �ȴ���");
        }
    }
}
