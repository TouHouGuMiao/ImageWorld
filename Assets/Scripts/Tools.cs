using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{
    public static T FindRecursively<T>(this Transform root, string name) where T : MonoBehaviour
    {
        Transform t = FindRecursively(root, name);
        if (t == null)
        {
            Debug.LogError(string.Format("null in ") + root);
            return null;
        }
        T t2 = t.GetComponent<T>();
        if (t2 == null)
        {
            Debug.LogError("null Component in " + root.name);
            return null;
        }
        return t2;
    }





    public static Transform FindRecursively(this Transform root, string name)
    {
        if (root.name == name)
        {
            return root;
        }
        foreach (Transform child in root)
        {
            Transform t = FindRecursively(child, name);
            if (t != null)
            {
                return t;
            }
        }

        return null;
    }
}
