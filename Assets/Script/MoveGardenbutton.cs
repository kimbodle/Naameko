using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGardenbutton : MonoBehaviour
{
    public void OnMoveGardenButtonClick()
    {
        Debug.Log("MoveGardenbutton clicked");  // 이 로그가 여러 번 출력되는지 확인

        // MoveScene 싱글턴 인스턴스의 MoveGarden 함수 호출
        MoveScene.Instance.MoveGarden();
    }
}
