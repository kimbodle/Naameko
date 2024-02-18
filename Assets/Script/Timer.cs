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
            // 60초 동안 value가 100에서 0으로 감소하도록 속도를 조절
            slTimer.value -= Time.deltaTime * (slTimer.maxValue / 60f);

            // value가 0이면 is1을 false로 설정
            if (slTimer.value <= 0)
            {
                itemManager.SpawnOk = false;
                Debug.Log("1분끝");
            }
        }
        else if (itemManager.is15)
        {
            // 60초 동안 value가 100에서 0으로 감소하도록 속도를 조절
            slTimer.value -= Time.deltaTime * (slTimer.maxValue / 600f);

            // value가 0이면 is1을 false로 설정
            if (slTimer.value <= 0)
            {
                itemManager.SpawnOk = false;
                Debug.Log("15분 끝");
            }
        }
        else
        {
            Debug.Log("시간 안눌림");
        }
    }
}
