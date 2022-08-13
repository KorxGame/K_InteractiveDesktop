using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Start()
    {
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * 30 * Time.deltaTime);
        
    }
}
