using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public static MoveScene Instance; // 싱글턴 인스턴스

    [SerializeField]
    public GameObject gardenObjects;

    void Awake()
    {
        // 싱글턴 인스턴스 설정
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
        Debug.Log("도감으로 이동");
        SceneManager.LoadScene("Library");

        // 씬이 로드된 후에 gardenObjects를 비활성화하도록 코루틴 호출
        StartCoroutine(DisableGardenObjectsAfterSceneLoad());
        
    }

    private IEnumerator DisableGardenObjectsAfterSceneLoad()
    {
        // 씬 로드가 완료될 때까지 기다림
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Library");

        // 씬 로드가 완료된 후에 gardenObjects를 비활성화
        gardenObjects.SetActive(false);
    }

    public void MoveGarden()
    {
        SceneManager.LoadScene("Garden");
        gardenObjects.SetActive(true);
        
    }
}

