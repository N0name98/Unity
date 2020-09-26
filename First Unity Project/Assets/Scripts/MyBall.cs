using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //rigid.velocity = new Vector3(2, 4, 3);
        //rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetButtonDown("Jump"))
    //     {
    //         rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
    //     }
    //     Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    //     rigid.AddForce(vec, ForceMode.Impulse);

    //     //rigid.AddTorque(Vector3.up);
    // }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);

        rigid.AddForce(vec, ForceMode.Impulse);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube")
        {
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }
}
