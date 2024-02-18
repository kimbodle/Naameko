using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Nameko : MonoBehaviour
{
    //수확만 담당하도록 delegate - event 사용
    public delegate void NamekoHarvestedDelegate(int id,int Np, Transform transform);
    public static event NamekoHarvestedDelegate OnNamekoHarvested;

    [SerializeField]
    private int id;
    public int Np;

    private void OnMouseDown()
    {

        //수확
        GameManager.Instance.HarvestNameko(id, Np);  // 나메코 수확 정보를 업데이트
        
        //버튼 UI가 아닌 오브젝트이기 때문에 OnMouseDown()사용
        //이벤트 발생
        OnNamekoHarvested?.Invoke(id, Np, transform);
        
        Destroy(gameObject,0.5f);
    }
}
