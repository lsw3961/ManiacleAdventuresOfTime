using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    //[SerializeField] private List<string> dontDestroyOnContactList = new List<string>();
    [SerializeField] private string theTag = "untagged";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //for (int i = 0; i < dontDestroyOnContactList.Count ; i++)
        //{
            if (collision.gameObject.tag == theTag)
            {
                gameObject.SetActive(false);
                return;
            }
            else
            {
                gameObject.SetActive(true);
            }
        //}

    }
}
