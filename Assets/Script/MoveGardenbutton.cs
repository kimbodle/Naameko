using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGardenbutton : MonoBehaviour
{
    public void OnMoveGardenButtonClick()
    {
        Debug.Log("MoveGardenbutton clicked");  // �� �αװ� ���� �� ��µǴ��� Ȯ��

        // MoveScene �̱��� �ν��Ͻ��� MoveGarden �Լ� ȣ��
        MoveScene.Instance.MoveGarden();
    }
}
