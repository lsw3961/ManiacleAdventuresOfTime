using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameManagerInfo info;
    [SerializeField]List<GameObject> redObjects = new List<GameObject>();
    [SerializeField]List<GameObject> greenObjects = new List<GameObject>();
    [SerializeField]List<GameObject> blueObjects = new List<GameObject>();
    [SerializeField] private float changeTimer = 15f;
    private float currentTime = 0f;

    public void FixedUpdate()
    {
        if (currentTime >= changeTimer)
        {
            currentTime = 0;
            info.Change();
            changeFilter();
        }
        currentTime += Time.deltaTime;
    }

    private void changeFilter()
    {
        if (info.CurrentState() == states.red)
        {
            Active(true,redObjects);
            Active(false,greenObjects);
            Active(false,blueObjects);
        }
        else if (info.CurrentState() == states.green)
        {
            Active(false, redObjects);
            Active(true, greenObjects);
            Active(false, blueObjects);
        }
        else
        {
            Active(false, redObjects);
            Active(false, greenObjects);
            Active(true, blueObjects);
        }
    }

    private void Active(bool isActive, List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(isActive);
        }
    }
}
