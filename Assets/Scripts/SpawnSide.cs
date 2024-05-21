using UnityEngine;

struct SpawnSide
{
    public Vector2 vector1;
    public Vector2 vector2;
    public float rotation;

    public SpawnSide(Vector2 vector1, Vector2 vector2, float rotation)
    {
        this.vector1 = vector1;
        this.vector2 = vector2;
        this.rotation = rotation;
    }
}