using UnityEngine;

struct SpawnSide
{
    public string name;
    public Vector2 vector1;
    public Vector2 vector2;
    public float rotation;

    public static string TOP = "TOP";
    public static string RIGHT = "RIGHT";
    public static string BOTTOM = "BOTTOM";
    public static string LEFT = "LEFT";

    public SpawnSide(string name, Vector2 vector1, Vector2 vector2, float rotation)
    {
        this.name = name;
        this.vector1 = vector1;
        this.vector2 = vector2;
        this.rotation = rotation;
    }
}