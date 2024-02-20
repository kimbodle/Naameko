using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool is1 = false;
    public bool is15 = false;
    public bool SpawnOk = false;
    public bool itemFull = false;

    public Timer timer;  // Timer 클래스의 인스턴스를 참조하는 필드 추가

    public bool isButtonCoolingDown = false;

    public void Time1()
    {
        is1 = !is1;
        SpawnOk = true;

        // 슬라이더를 최대값으로 초기화
        timer.slTimer.value = timer.slTimer.maxValue;
    }

    public void Time15()
    {
        is15 = !is15;
        SpawnOk=true;

        // 슬라이더를 최대값으로 초기화
        timer.slTimer.value = timer.slTimer.maxValue;
    }

    public void Item_Full()
    {
        if (GameManager.Instance.GetTotalNp() > 30)
        {
            if (isButtonCoolingDown)
                return;

            StartCoroutine(StartButtonCooldown());
            isButtonCoolingDown = true;

            itemFull = true;
            GameManager.Instance.totalNp -= 30;
        }
        else
        {
            Debug.Log("돈 없음");
        }
        
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
    

    IEnumerator StartButtonCooldown()
    {
        yield return new WaitForSeconds(5f);
        isButtonCoolingDown = false;
    }
}
