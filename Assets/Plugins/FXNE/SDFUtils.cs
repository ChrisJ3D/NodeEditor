// Shamelessly stolen from
// http://www.iquilezles.org/www/articles/distfunctions/distfunctions.htm
//
// There's some private functions at the bottom designed to make the syntax
// somewhat more similar to that of HLSL.

using System;
using UnityEngine;

public static class SDFUtils {

    //  Sphere - Unsigned - Exact
    public static float udSphere(Vector3 position, float size) {
        return position.magnitude - size;
    }

    //  Box - Unsigned - Exact
    public static float udBox(Vector3 position, Vector3 bounds) {        
        return Max(Abs(position) - bounds, 0.0f).magnitude;
    }

    //  Cylinder - Signed - Exact
    public static float sdCylinder (Vector3 position, Vector3 center) {
        float x = position.x - center.x;
        float y = position.y - center.y;
        float z = position.z;

        return new Vector3(x,y,z).magnitude - center.z;
    }

    //  Plane - Signed - Exact
    public static float sdPlane (Vector3 position, Vector4 n) {
        return 0.0f;

    }

    private static float Dot(Vector3 a, Vector3 b) {
        return 0.0f;
    }

    private static Vector2 Max(Vector2 a, float b) {
        float x = Mathf.Max(a.x, b);
        float y = Mathf.Max(a.y, b);

        return new Vector2(x,y);
    }

    private static Vector3 Max(Vector3 a, float b) {
        float x = Mathf.Max(a.x, b);
        float y = Mathf.Max(a.y, b);
        float z = Mathf.Max(a.z, b);

        return new Vector3(x,y,z);
    }

    private static Vector4 Max(Vector4 a, float b) {
        float x = Mathf.Max(a.x, b);
        float y = Mathf.Max(a.y, b);
        float z = Mathf.Max(a.z, b);
        float w = Mathf.Max(a.w, b);

        return new Vector4(x,y,z,w);
    }

    private static Vector2 Abs(Vector2 a) {
        float x = Mathf.Abs(a.x);
        float y = Mathf.Abs(a.y);

        return new Vector2(x,y);
    }

    private static Vector3 Abs(Vector3 a) {
        float x = Mathf.Abs(a.x);
        float y = Mathf.Abs(a.y);
        float z = Mathf.Abs(a.z);

        return new Vector3(x,y,z);
    }

    private static Vector4 Abs(Vector4 a) {
        float x = Mathf.Abs(a.x);
        float y = Mathf.Abs(a.y);
        float z = Mathf.Abs(a.z);
        float w = Mathf.Abs(a.w);

        return new Vector4(x,y,z, w);
    }
}
