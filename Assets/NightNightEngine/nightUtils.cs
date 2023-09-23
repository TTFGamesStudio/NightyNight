using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class nightUtils
{
    public static float SmootherLerp(float start, float end, float sharpness)
    {
        return Mathf.Lerp(start, end, 1f - Mathf.Exp(-sharpness * Time.deltaTime));
    }

    public static Vector2 SmootherLerp(Vector2 start, Vector2 end, float sharpness)
    {
        return new Vector2(
            SmootherLerp(start.x, end.x, sharpness),
            SmootherLerp(start.y, end.y, sharpness));
    }
    
    public static Vector3 SmootherLerp(Vector3 start, Vector3 end, float sharpness)
    {
        return new Vector3(
            SmootherLerp(start.x, end.x, sharpness),
            SmootherLerp(start.y, end.y, sharpness),
            SmootherLerp(start.z, end.z, sharpness));
    }
    
    public static Vector4 SmootherLerp(Vector4 start, Vector4 end, float sharpness)
    {
        return new Vector4(
            SmootherLerp(start.x, end.x, sharpness),
            SmootherLerp(start.y, end.y, sharpness),
            SmootherLerp(start.z, end.z, sharpness),
            SmootherLerp(start.w, end.w, sharpness));
    }
    
    public static UnityEngine.Color SmootherLerp(UnityEngine.Color start, UnityEngine.Color end, float sharpness)
    {
        return new UnityEngine.Color(
            SmootherLerp(start.r, end.r, sharpness),
            SmootherLerp(start.g, end.g, sharpness),
            SmootherLerp(start.b, end.b, sharpness),
            SmootherLerp(start.a, end.a, sharpness));
    }
    
    public static Quaternion SmootherLerp(Quaternion start, Quaternion end, float sharpness)
    {
        return Quaternion.Euler(
            SmootherLerp(start.eulerAngles.x, end.eulerAngles.x, sharpness),
            SmootherLerp(start.eulerAngles.y, end.eulerAngles.y, sharpness),
            SmootherLerp(start.eulerAngles.z, end.eulerAngles.z, sharpness));
    }
}
