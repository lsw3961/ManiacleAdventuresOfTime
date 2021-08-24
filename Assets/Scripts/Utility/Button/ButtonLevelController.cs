using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonLevelController : MonoBehaviour
{

    public void ChangeLevels(int levelNumber)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(levelNumber));
    }

}
