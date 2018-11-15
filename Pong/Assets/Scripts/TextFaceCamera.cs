using UnityEngine;
using System.Collections;

public class TextFaceCamera : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.current.transform.position);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
