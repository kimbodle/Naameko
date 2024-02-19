using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Nameko : MonoBehaviour
{
    public GameObject wiltedNamekoPrefab;  // 시든 나메코 프리팹
    public float timeToWilt = 10f;  // 시들기까지의 시간

    private Animator animator;

    [SerializeField]
    private int id;
    public int Np;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(WiltAfterTime());
    }

    private IEnumerator WiltAfterTime()
    {
        yield return new WaitForSeconds(timeToWilt);

        // 시든 나메코 프리팹으로 교체
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        Transform parent = transform.parent;
        Destroy(gameObject);
        Instantiate(wiltedNamekoPrefab, position, rotation, parent);
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("isHavesting");
        //수확
        GameManager.Instance.HarvestNameko(id, Np);  // 나메코 수확 정보를 업데이트

        //버튼 UI가 아닌 오브젝트이기 때문에 OnMouseDown()사용
        //이벤트 발생
        HavestEventManager.HarvestNameko(id, Np, transform);

        Destroy(gameObject,1.5f);
    }
}
