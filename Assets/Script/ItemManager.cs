using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool is1 = false;
    public bool is15 = false;
    public bool SpawnOk = false;

    public Timer timer;  // Timer Ŭ������ �ν��Ͻ��� �����ϴ� �ʵ� �߰�

    public void Time1()
    {
        is1 = !is1;
        SpawnOk = true;

        // �����̴��� �ִ밪���� �ʱ�ȭ
        timer.slTimer.value = timer.slTimer.maxValue;
    }

    public void Time15()
    {
        is15 = !is15;
        SpawnOk=true;

        // �����̴��� �ִ밪���� �ʱ�ȭ
        timer.slTimer.value = timer.slTimer.maxValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        is1 = true;
        SpawnOk = true;
    }

    private void OnEnable()
    {
        SpawnOk = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
