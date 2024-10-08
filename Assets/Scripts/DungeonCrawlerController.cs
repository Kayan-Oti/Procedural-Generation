using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up = 0,
    left,
    down,
    right
}

public class DungeonCrawlerController
{
    //Dicionário que converte Direction em Vector2Int
    public static readonly Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int>
    {
        {Direction.up, Vector2Int.up},
        {Direction.left, Vector2Int.left},
        {Direction.down, Vector2Int.down},
        {Direction.right, Vector2Int.right},
    };

    public static List<Vector2Int> GeneratePositions(DungeonData dungeonData)
    {
        //Lista de Crawlers
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();
        //Listas de posição que sera retornada
        List<Vector2Int> positionVisited = new List<Vector2Int>();

        //Cria determinado numero de Crawlers
        for(int i = 0; i < dungeonData.numberOfCrawlers; i++){
            dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
        }

        //Número total de posições que devem ser preenchidas
        //Valor aleatório entre o Mínimo e o Máximo do dungeonData
        int totalPositions = Random.Range(dungeonData.roomsMin, dungeonData.roomsMax);

        //Sempre gera a posição inicial 0,0
        positionVisited.Add(Vector2Int.zero);

        //Loop que faz os crawlers se moverem e adicionarem novas coordenadas
        while(positionVisited.Count < totalPositions)
        {
            //Percorre cada crawler e move sua posição
            foreach(DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                //Move o crawler atual
                Vector2Int newPosition = dungeonCrawler.MoveToRandomDirection(directionMovementMap);

                //Verifica se a posição do crawler já existe na lista
                if(positionVisited.Exists(pos => pos.x == newPosition.x && pos.y == newPosition.y))
                    continue;

                //Adiciona a nova posição ao lista
                positionVisited.Add(newPosition);

                //Verifica se total de posição foi atingido e encerra o loop
                if(positionVisited.Count >= totalPositions)
                    break; 
            }
        }

        return positionVisited;
    }
}
