using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalController : MonoBehaviour
{

    private void OnCollisionEnter(Collision obj)
    {
        Debug.Log("carpisma gerceklesti..");
        Destroy(obj.gameObject);
        Application.LoadLevel("Won");
        // kazandınız sahnesine gitmeli
    }
}
