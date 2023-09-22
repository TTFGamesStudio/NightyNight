using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class nightUtils
{
    public static float smootherLerp(float start, float end, float sharpness)
    {
        return Mathf.Lerp(start, end, 1f - Mathf.Exp(-sharpness * Time.deltaTime));
    }

    public static Vector2 smootherLerp(Vector2 start, Vector2 end, float sharpness)
    {
        return new Vector2(
            smootherLerp(start.x, end.x, sharpness),
            smootherLerp(start.y, end.y, sharpness));
    }
    
    public static Vector3 smootherLerp(Vector3 start, Vector3 end, float sharpness)
    {
        return new Vector3(
            smootherLerp(start.x, end.x, sharpness),
            smootherLerp(start.y, end.y, sharpness),
            smootherLerp(start.z, end.z, sharpness));
    }
    
    public static Vector4 smootherLerp(Vector4 start, Vector4 end, float sharpness)
    {
        return new Vector4(
            smootherLerp(start.x, end.x, sharpness),
            smootherLerp(start.y, end.y, sharpness),
            smootherLerp(start.z, end.z, sharpness),
            smootherLerp(start.w, end.w, sharpness));
    }
    
    public static UnityEngine.Color smootherLerp(UnityEngine.Color start, UnityEngine.Color end, float sharpness)
    {
        return new UnityEngine.Color(
            smootherLerp(start.r, end.r, sharpness),
            smootherLerp(start.g, end.g, sharpness),
            smootherLerp(start.b, end.b, sharpness),
            smootherLerp(start.a, end.a, sharpness));
    }
    
    public static Quaternion smootherLerp(Quaternion start, Quaternion end, float sharpness)
    {
        return Quaternion.Euler(
            smootherLerp(start.eulerAngles.x, end.eulerAngles.x, sharpness),
            smootherLerp(start.eulerAngles.y, end.eulerAngles.y, sharpness),
            smootherLerp(start.eulerAngles.z, end.eulerAngles.z, sharpness));
    }
}
