using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Update()
    {
        Vector3 vec = new Vector3(
        Input.GetAxisRaw("Horizontal") * Time.deltaTime,
        Input.GetAxisRaw("Vertical") * Time.deltaTime);
        transform.Translate(vec);
    }
}
