using UnityEngine;

struct SpawnSide
{
    public string name;
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float rotation;

    public static string TOP = "TOP";
    public static string RIGHT = "RIGHT";
    public static string BOTTOM = "BOTTOM";
    public static string LEFT = "LEFT";

    public SpawnSide(string name, Vector2 startPoint, Vector2 endPoint, float rotation)
    {
        this.name = name;
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.rotation = rotation;
    }
}