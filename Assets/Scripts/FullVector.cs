using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FullVector
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    public FullVector(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }
}

[System.Serializable]
public class HistoryScene
{
    public List<FullVector> SceneObjects;
}