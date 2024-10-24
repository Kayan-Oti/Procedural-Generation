using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Dungeon Data")]

public class DungeonData : ScriptableObject
{
    public int numberOfCrawlers;
    public int roomsMin;
    public int roomsMax;
}