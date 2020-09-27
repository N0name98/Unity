using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherBall : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "My Ball")
        {
            mat.color = new Color(0, 0, 0);
        }

    }
    // void OnCollisionStay(Collision other)
    // {

    // }
    void OnCollisionExit(Collision other)
    {
        mat.color = new Color(1, 1, 1);
    }
}
