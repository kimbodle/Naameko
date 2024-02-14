using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Nameko : MonoBehaviour
{
    //수확만 담당하도록 delegate - event 사용
    public delegate void NamekoHarvestedDelegate(int id);
    public static event NamekoHarvestedDelegate OnNamekoHarvested;

    public int id;

    private void OnMouseDown()
    {
        //이벤트 발생
        OnNamekoHarvested?.Invoke(id);

        //수확
        Destroy(gameObject);
    }
}
