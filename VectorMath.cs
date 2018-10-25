using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VectorMath : MonoBehaviour {

#region Week 2 Functions

    public static  Vector2 VectorAdd(Vector2 A, Vector2 B)
    {
        Vector2 C = new Vector2((A.x + B.x), (A.y + B.y));

        return C;
    }

    public static Vector3 VectorAdd(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3((A.x + B.x), (A.y + B.y), (A.z + B.z));

        return C;
    }

    public static Vector2 VectorSubtract(Vector2 A, Vector2 B)
    {
        Vector2 C = new Vector2((A.x - B.x), (A.y - B.y));

        return C;
    }

    public static Vector3 VectorSubtract(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3((A.x - B.x), (A.y - B.y), (A.z - B.z));

        return C;
    }

    public static float VectorLength(Vector2 A)
    {
        return (Mathf.Sqrt((A.x * A.x) + (A.y * A.y)));
    }

    public static float VectorLength(Vector3 A)
    {
        return (Mathf.Sqrt((A.x * A.x) + (A.y * A.y) + (A.z * A.z)));
    }

    #endregion


#region Week 3 Functions

    public static float LengthSq(Vector2 A)
    {
        return ((A.x * A.x) + (A.y * A.y));
    }

    public static float LengthSq(Vector3 A)
    {
        return ((A.x * A.x) + (A.y * A.y) + (A.z * A.z));
    }

    
    public static Vector2 VectorScale(Vector2 A, float scalar)
    {
        Vector2 B = new Vector2((A.x * scalar), (A.y * scalar));

        return B;
    }

    public static Vector3 VectorScale(Vector3 A, float scalar)
    {
        Vector3 B = new Vector3((A.x * scalar), (A.y * scalar), (A.z * scalar));

        return B;
    }


    public static Vector2 VectorDivide(Vector2 A, float divisor)
    {
        Vector2 B = new Vector2((A.x / divisor), (A.y / divisor));

        return B;
    }

    public static Vector3 VectorDivide(Vector3 A, float divisor)
    {
        Vector3 B = new Vector3((A.x / divisor), (A.y / divisor), (A.z / divisor));

        return B;
    }


    public static Vector2 VectorNormal(Vector2 A)
    {
        float length = VectorLength(A);

        Vector2 B = new Vector2((A.x / length), (A.y / length));

        return B;
    }

    public static Vector3 VectorNormal(Vector3 A)
    {
        float length = VectorLength(A);

        Vector3 B = new Vector3((A.x / length), (A.y / length), (A.z / length));

        return B;
    }

    public static float VectorDotProduct(Vector2 A, Vector2 B, bool Normalize)
    {
        if (Normalize)
        {
            A = VectorNormal(A);
            B = VectorNormal(B);
        }
        

        return ((A.x * B.x) + (A.y * B.y));
    }

    public static float VectorDotProduct(Vector3 A, Vector3 B, bool Normalise)
    {
        if (Normalise)
        {
            A = VectorNormal(A);
            B = VectorNormal(B);
        }


        return ((A.x * B.x) + (A.y * B.y) + (A.z * B.z));
    }

    public static Vector3 VectorCrossProduct(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3();
        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;

        return C;
    }


    #endregion


#region Week 4 Functions

    public static float DegreeToRadian(float degrees)
    {
        return (degrees / (180/Mathf.PI));
    }

    public static float FindAngle(Vector2 V)
    {
        return Mathf.Atan(V.y / V.x);
    }

    public static Vector2 FindVector(float angle)
    {
        Vector2 C;
        C.x = Mathf.Cos(angle);
        C.y = Mathf.Sin(angle);

        return C;
    }
    #endregion

#region Week 5 Functions
    public static Vector3 VectorLerp(Vector3 A, Vector3 B, float T) 
    {
        Vector3 C = (A * (1.0f - T)) + (B * T);

        return C;
    }

    public static Vector2 VectorLerp(Vector2 A, Vector2 B, float T)
    {
        Vector2 C = (A * (1.0f - T)) + (B * T);

        return C;
    }

    #endregion

#region Week 7 Functions

    public static Vector3 AxisAngleMethod(float angle, Vector3 axis, Vector3 vertex)
    {
        Vector3 rv = (vertex * Mathf.Cos(angle)) + VectorDotProduct(vertex, axis, true) * axis * (1 - Mathf.Cos(angle)) + VectorCrossProduct(axis, vertex) * Mathf.Sin(angle);
        return rv;
    }

#endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
