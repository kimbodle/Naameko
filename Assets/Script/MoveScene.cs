using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void MoveLibrary()
    {
        SceneManager.LoadScene("Library");
    }

    public void MoveGarden()
    {
        SceneManager.LoadScene("Garden");
    }
}
