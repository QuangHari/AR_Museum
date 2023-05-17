using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DeleteCache : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Caching.ClearCache();
        AssetDatabase.Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
