using UnityEngine;

public static class Helpers
{
    private static Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0f, 45f, 0f));

    public static Vector3 ToIso(this Vector3 input) => isoMatrix.MultiplyPoint3x4(input);
    
}
