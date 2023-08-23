using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prolog2 : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    public void Activate2()
    {
        StartCoroutine(kopalnie());
    }
    private System.Collections.IEnumerator kopalnie()
    {
        yield return new WaitForSeconds(10.5f);
        transform.position = playerTransform.position + offset;
    }
}
