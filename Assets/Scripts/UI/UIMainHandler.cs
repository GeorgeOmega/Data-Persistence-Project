using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainHandler : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}