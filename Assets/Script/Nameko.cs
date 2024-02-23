using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Nameko : MonoBehaviour
{
    public GameObject wiltedNamekoPrefab;  // �õ� ������ ������
    public float timeToWilt = 10f;  // �õ������� �ð�

    private Animator animator;
    private AudioSource sound;

    [SerializeField]
    private int id;
    public int Np;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        StartCoroutine(WiltAfterTime());
    }

    private IEnumerator WiltAfterTime()
    {
        yield return new WaitForSeconds(timeToWilt);

        // �õ� ������ ���������� ��ü
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        Transform parent = transform.parent;
        Destroy(gameObject);
        Instantiate(wiltedNamekoPrefab, position, rotation, parent);
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("isHavesting");
        //��Ȯ
        GameManager.Instance.HarvestNameko(id, Np);  // ������ ��Ȯ ������ ������Ʈ

        //��ư UI�� �ƴ� ������Ʈ�̱� ������ OnMouseDown()���
        //�̺�Ʈ �߻�
        HavestEventManager.HarvestNameko(id, Np, transform);
        sound.Play();

        Destroy(gameObject,1.5f);
    }
}
