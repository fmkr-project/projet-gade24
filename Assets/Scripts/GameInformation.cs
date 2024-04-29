using System;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
    public static Creature Data;
    public static Vector3 PlayerPosition = new Vector3(50.0f, 0.0f, 50.0f);
    public static Vector3 CameraPosition;
    public static Bag bag = new();
    public static Squad squad = new();

    public static Creature GetData()
    {
        print($"data is {Data.Id}");
        return Data;
    }

    public static void SetData(Creature creature)
    {
        Data = creature;
        print($"data to {Data.Id}");
    }

    public static Vector3 GetPosition()
    {
        return PlayerPosition;
    }

    public static void SetPosition(Vector3 position)
    {
        PlayerPosition = position;
    }
    
    public static Vector3 GetCameraPosition()
    {
        return CameraPosition;
    }

    public static void SetCameraPosition(Vector3 position)
    {
        CameraPosition = position;
    }
}