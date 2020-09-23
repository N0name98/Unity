using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello Unity!");

        int level = 5;
        float stength = 15.5f;
        string playerName = "나검사";
        bool isFullLevel = false;

        Debug.Log("Hello Unity!");

        List<string> items = new List<string>();
        items.Add("생명물약30");
        items.Add("마나물약30");

        Debug.Log("가지고 있는 아이템");
        Debug.Log(items[0]);
    }
}
