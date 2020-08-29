using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Utils
{
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator int[](POINT point)
        {
            int[] i = new int[2];
            i[0] = point.X;
            i[1] = point.Y;
            return i;
        }
    }
    public static int[] GetCursorPosition()
    {
        POINT lpPoint;
        GetCursorPos(out lpPoint);

        return lpPoint;
    }
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);

    public static GameObject FindChildGameObjectByTag(GameObject parent, string tag)
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject child in list)
        {
            if (child.transform.IsChildOf(parent.transform))
            {
                return child;
            }
        }
        return null;
    }

    public static List<Vector3> GeneratePerfectCircleAroundLocation(Vector3 location, float additionalHeightStart, int objectCount, int radius)
    {
        List<Vector3> v3List = new List<Vector3>();
        Vector3 v3 = new Vector3(location.x, location.y + additionalHeightStart, location.z);

        float inc = 1f / objectCount;
        for (float i = 0; i < objectCount; i += inc)
        {
            float theta = i * 2 * Mathf.PI;

            v3.x = location.x + radius * Mathf.Cos(theta);
            v3.z = location.z + radius * Mathf.Sin(theta);
            v3List.Add(new Vector3(v3.x, v3.y, v3.z));
        }

        return v3List;
    }

    public static List<Vector3> GenerateAngularCircleAroundLocation(Vector3 location, float additionalHeightStart, int objectCount, int radius)
    {
        List<Vector3> v3List = new List<Vector3>();
        Vector3 v3 = new Vector3(location.x, location.y + additionalHeightStart, location.z);

        float inc = 2f / objectCount;
        for (float i = 0; i < objectCount; i += inc)
        {
            float theta = i * 2 * Mathf.PI;

            v3.x = location.x + radius * Mathf.Cos(theta);
            v3.z = location.z + radius * Mathf.Sin(theta);
            v3List.Add(new Vector3(v3.x, v3.y, v3.z));
        }

        return v3List;

    }

    public static Vector3 getObjectBounds(Component component)
    {
        return getObjectBounds(component.gameObject);
    }

    public static Vector3 getObjectBounds(GameObject gameObject)
    {
        return gameObject.GetComponent<Renderer>().bounds.size;
    }

}
