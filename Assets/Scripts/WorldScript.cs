using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class WorldScript {

    [MenuItem("Debug/Print Global Position")]
    public static void PrintGlobalPosition()
    {
        if (Selection.activeGameObject != null)
        {
            Debug.Log(Selection.activeGameObject.name + " is at " + Selection.activeGameObject.transform.position);
        }
    }
}
