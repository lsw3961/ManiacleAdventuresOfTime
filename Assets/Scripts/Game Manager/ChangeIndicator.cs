using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIndicator : MonoBehaviour
{
    public GameManagerInfo info;
    [SerializeField] private float headsUpTimer = 2f;
    [SerializeField] private float blinkRate = .6f;
    [SerializeField] private List<GameObject> blinkIndicators = new List<GameObject>();
    private void FixedUpdate()
    {
        if (info.MaxTime - info.currentTime < headsUpTimer)
        {
            Debug.Log("Print Me");
            BlinkOn();
            StartCoroutine("BlinkOff",0f);
        }
        else
        {
            BlinkOff();
        }
    }

    private void BlinkOn()
    {
        if (blinkIndicators.Count != 0)
        {
            for (int i = 0; i < blinkIndicators.Count; i++)
            {
                blinkIndicators[i].SetActive(true);
            }
        }

    }

    private IEnumerator BlinkOff()
    {
        yield return new WaitForSecondsRealtime(blinkRate);
        if (blinkIndicators.Count != 0)
        {
            for (int i = 0; i < blinkIndicators.Count; i++)
            {
                blinkIndicators[i].SetActive(false);
            }
        }

    }
}
