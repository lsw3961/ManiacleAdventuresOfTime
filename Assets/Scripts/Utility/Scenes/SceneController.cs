using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool restartLevelBool = false;
    public bool newLevelBool = false;
    public int level = 0;
    [SerializeField] float sceneStartDelayTimer = 1.5f;
    public Animator anim;
    public PlayerLife player;
    void FixedUpdate()
    {
        if (restartLevelBool || newLevelBool)
        {
            player.Reset();
            StartCoroutine("SceneChange");
        }
    }
    private IEnumerator SceneChange()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(sceneStartDelayTimer);
        SceneManager.LoadScene(level);
    }

    public void RestartTheLevel()
    {
        restartLevelBool = true;
        level = player.CurerntLevel;
    }
    public void ChangeLevels(int scene)
    {
        restartLevelBool = true;
        level = scene;
    }
}
