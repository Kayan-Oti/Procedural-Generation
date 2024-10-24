using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawler
{
    private Vector2Int _position;

    public DungeonCrawler()
    {
        _position = Vector2Int.zero;
    }

    //Dicionário que converte int em Vector2Int
    public static readonly Dictionary<int, Vector2Int> directionMovementMap = new Dictionary<int, Vector2Int>
    {
        {0, Vector2Int.up},
        {1, Vector2Int.left},
        {2, Vector2Int.down},
        {3, Vector2Int.right},
    };

    //Função que move o Crawler para uma direção aleatória
    public Vector2Int MoveToRandomDirection()
    {
        //Gera um número aleatório correspondente a uma direção
        int toMove = Random.Range(0, directionMovementMap.Count);
        //Move o crawler na direção aleatória
        _position += directionMovementMap[toMove];
        //Retorna a posição
        return _position;
    }
}

