using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public static MoveScene Instance; // �̱��� �ν��Ͻ�

    [SerializeField]
    public GameObject gardenObjects;

    void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveLibrary()
    {
        Debug.Log("�������� �̵�");
        SceneManager.LoadScene("Library");

        // ���� �ε�� �Ŀ� gardenObjects�� ��Ȱ��ȭ�ϵ��� �ڷ�ƾ ȣ��
        StartCoroutine(DisableGardenObjectsAfterSceneLoad());
        
    }

    private IEnumerator DisableGardenObjectsAfterSceneLoad()
    {
        // �� �ε尡 �Ϸ�� ������ ��ٸ�
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Library");

        // �� �ε尡 �Ϸ�� �Ŀ� gardenObjects�� ��Ȱ��ȭ
        gardenObjects.SetActive(false);
    }

    public void MoveGarden()
    {
        SceneManager.LoadScene("Garden");
        gardenObjects.SetActive(true);
        
    }
}

