using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawlerController
{
    public static List<Vector2Int> GeneratePositions(DungeonData dungeonData)
    {
        //Lista de Crawlers
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();
        //Listas de posições que será retornada
        List<Vector2Int> positionVisited = new List<Vector2Int>();

        //Gera determinado número de Crawlers
        for(int i = 0; i < dungeonData.numberOfCrawlers; i++){
            dungeonCrawlers.Add(new DungeonCrawler());
        }

        //Número total de posições que devem ser preenchidas
        //Valor aleatório entre o Mínimo e o Máximo
        int totalPositions = Random.Range(dungeonData.roomsMin, dungeonData.roomsMax+1);

        //Sempre gera a posição inicial 0,0
        positionVisited.Add(Vector2Int.zero);

        //Loop que faz os crawlers se moverem e adicionarem novas coordenadas
        while(positionVisited.Count < totalPositions)
        {
            //Percorre cada crawler e move sua posição
            foreach(DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                //Move o crawler atual
                Vector2Int newPosition = dungeonCrawler.MoveToRandomDirection();

                //Verifica se a posição do crawler já existe na lista
                if(positionVisited.Exists(pos => pos.Equals(newPosition))){
                    //Passa para o proximo item do foreach
                    continue;
                }

                //Adiciona a nova posição à lista
                positionVisited.Add(newPosition);

                //Verifica se o total de posições foi atingido
                if(positionVisited.Count >= totalPositions){
                    //Encerra o loop foreach
                    break; 
                }
            }
        }

        //Retorna a lista de posições
        return positionVisited;
    }
}

// public class DungeonCrawlerController
// {
//     public static List<Vector2Int> GeneratePositions(DungeonData dungeonData)
//     {
//         //Lista de Crawlers
//         List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();
//         //Listas de posições que será retornada
//         List<Vector2Int> positionVisited = new List<Vector2Int>();

//         //Gera determinado número de Crawlers
//         for(int i = 0; i < dungeonData.numberOfCrawlers; i++){
//             dungeonCrawlers.Add(new DungeonCrawler());
//         }

//         //Número total de posições que devem ser preenchidas
//         //Valor aleatório entre o Mínimo e o Máximo do dungeonData
//         int totalPositions = Random.Range(dungeonData.roomsMin, dungeonData.roomsMax);

//         //Sempre gera a posição inicial 0,0
//         positionVisited.Add(Vector2Int.zero);

//         //Loop que faz os crawlers se moverem e adicionarem novas coordenadas
//         while(positionVisited.Count < totalPositions)
//         {
//             //Percorre cada crawler e move sua posição
//             foreach(DungeonCrawler dungeonCrawler in dungeonCrawlers)
//             {
//                 //Move o crawler atual
//                 Vector2Int newPosition = dungeonCrawler.MoveToRandomDirection();

//                 //Verifica se a posição do crawler já existe na lista
                // if(positionVisited.Exists(pos => pos.x == newPosition.x && pos.y == newPosition.y)){
                //     //Passa para o proximo item do foreach
                //     continue;
                // }

//                 //Adiciona a nova posição à lista
//                 positionVisited.Add(newPosition);

//                 //Verifica se o total de posições foi atingido e encerra o loop
//                 if(positionVisited.Count >= totalPositions)
//                     break; 
//             }
//         }
            //Retorna a lista de posições
//         return positionVisited;
//     }
// }
