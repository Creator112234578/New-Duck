using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLock : MonoBehaviour
{
    public GameObject Lock;
    public GameObject Key;
    public GameObject Door;
    private void Update()
    {
        if (Lock != null && Key != null && Lock.GetComponent<Collider>().bounds.Intersects(Key.GetComponent<Collider>().bounds))
        {
            Destroy(Door);
            Destroy(Key);
            Destroy(Lock);
        }
    }
}