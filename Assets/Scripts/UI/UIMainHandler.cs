using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainHandler : UIMenuHandler
{
    public override void Exit() //POLYMORPHISM AND INHERITANCE
    {
        SceneManager.LoadScene(0);
    }
}
