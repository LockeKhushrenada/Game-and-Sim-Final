using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : GameplayComponent
{
    public string sceneName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void UpdateButton()
    {
        if (Input.GetKeyDown(GetKeyFromButtonType(key)))
        {
            GoToScene();
        }
    }

    protected override void UpdateConstant()
    {
        GoToScene();
    }

    protected override void UpdateOneShot()
    {
        if(!completed && active)
        {
            GoToScene();
            completed = true;
        }
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
