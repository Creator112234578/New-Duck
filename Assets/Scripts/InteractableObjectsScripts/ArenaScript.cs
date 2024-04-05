using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    public List<Vector3> pos = new List<Vector3>();
    public int counter;
    public bool move;
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            foreach (Transform target in targets)
            {
                target.localPosition = pos[counter];
                counter += 1;
            }
        }
    }
}
