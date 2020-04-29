using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class MapManager : MonoBehaviour
{

    public String CurrentLevel;

    public GameObject Grass1;

    public GameObject Grass2;

    public GameObject RoadCross, RoadEndHorizontal, RoadEndHorizontal2Left, RoadEndVertical2, RoadEndVertical2Down, RoadMiddleHorizontal, RoadMiddleVertical1, Tree;

    public GameObject PlayerPrefab, MorahPrefab, LionelPrefab, EnemyPrefab;


    public GameObject PlatGrass1;

    XmlDocument xmlDocument;

    GameObject currentPrefab = null;

    Transform cellsContainer, charactersContainer;

    XmlNode currentNode;

    XmlNodeList nodeList;

    void Start()
    {
        xmlDocument = new XmlDocument();

        xmlDocument.LoadXml(Resources.Load<TextAsset>("Level1").text);
        
        LoadMap();
    }


    private void Awake()
    {
        cellsContainer = GameObject.Find("Cells").transform;
        charactersContainer = GameObject.Find("Characters").transform;
    }


    void LoadMap()
    {
        // loading the map

        currentPrefab = null;

        nodeList = xmlDocument.SelectNodes("//level/map/row");

        for(int i = 0; i < nodeList.Count; i++)
        {
            currentNode = nodeList[i];

            for (int j = 0; j < currentNode.InnerText.Length; j++)
            {
                switch (currentNode.InnerText[j])
                {
                    case 'A':
                    currentPrefab = Grass1;
                        break;

                    case 'B':
                    currentPrefab = Grass2;
                        break;

                    case 'C':
                    currentPrefab = RoadCross;
                        break;

                    case 'D':
                    currentPrefab = RoadEndHorizontal;
                        break;

                    case 'E':
                    currentPrefab = RoadEndHorizontal2Left;
                        break;

                    case 'F':
                    currentPrefab = RoadEndVertical2;
                        break;

                    case 'H':
                    currentPrefab = RoadMiddleHorizontal;
                        break;

                    case 'I':
                    currentPrefab = RoadMiddleVertical1;
                        break;

                    case 'J':
                    currentPrefab = Tree;
                        break;                        
                }

               currentPrefab = Instantiate(currentPrefab,new Vector3(j, -i), Quaternion.identity);

               currentPrefab.transform.SetParent(cellsContainer);
            }
        }

        LoadCharacters();
    }


    void LoadCharacters()
    {
        GameObject newElement;
        currentPrefab = null;
        nodeList = xmlDocument.SelectNodes("//level/characters/character");
        foreach( XmlNode currentElement in nodeList)
        {
            switch (currentElement.Attributes ["prefabName"].Value)
            {
                case "Player":
                    currentPrefab = PlayerPrefab;
                    break;
                case "Morah":
                    currentPrefab = MorahPrefab;
                    break;
                case "Lionel":
                    currentPrefab = LionelPrefab;
                    break;
                default:
                    currentPrefab = EnemyPrefab;
                    break;
            }
            newElement = Instantiate (currentPrefab, new Vector3(Convert.ToSingle(currentElement.Attributes["posX"].Value),-Convert.ToSingle(currentElement.Attributes["posY"].Value)),Quaternion.identity);

            newElement.name = currentElement.Attributes["uniqueObjectName"].Value;

            newElement.transform.SetParent(charactersContainer);

            if (newElement.tag == "Player")
            {    
                Camera.main.transform.SetParent(newElement.transform);

                Camera.main.transform.localPosition = new Vector3(0,0,Camera.main.transform.localPosition.z);
            }
        }
    }
}
