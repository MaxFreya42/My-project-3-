using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform AiPath;
    public static Transform[] paths {  get; private set; }

    void Start()
    {
        int n = AiPath.childCount;
        paths = new Transform[n];
        for (int i = 0; i < n; ++i)
        {
            paths[i] = AiPath.GetChild(i);
        }
    }

}
