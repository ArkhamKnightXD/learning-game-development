using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class MetroidMapManager : MonoBehaviour
{

    //public String CurrentLevel;

    public GameObject Acid1, Acid2, BgTile1, BgTile2, BgTile3, BgTile4, BgTile5, BgTile6,BgTile7,BgTile8, Fence1, Fence2,Fence3,Spike;

    public GameObject Tile1,Tile2,Tile3,Tile4,Tile5,Tile6,Tile7,Tile8,Tile9,Tile10,Tile11,Tile12,Tile13,Tile14,Tile15;

    public GameObject Barrel1,Barrel2,Box,DoorLocked,DoorOpen,DoorUnlocked,Saw,Switch1,Switch2, Jelly3;

    XmlDocument xmlDocument;

    GameObject currentPrefab;

    Transform cellsContainer, charactersContainer;

    XmlNode currentNode;

    XmlNodeList nodeList;

    void Start()
    {
        xmlDocument = new XmlDocument();

        xmlDocument.LoadXml(Resources.Load<TextAsset>("FinalVersion2").text);
        
        LoadMap();
    }


    private void Awake()
    {
        cellsContainer = GameObject.Find("Cells").transform;
       // charactersContainer = GameObject.Find("Characters").transform;
    }


    void LoadMap()
    {
        // loading the map

       // currentPrefab = null;

        nodeList = xmlDocument.SelectNodes("//level/map/row");

        for(int i = 0; i < nodeList.Count; i++)
        {
            currentNode = nodeList[i];

            for (int j = 0; j < currentNode.InnerText.Length; j++)
            {
                switch (currentNode.InnerText[j])
                {
                    case 'A':
                    currentPrefab = Acid1;
                        break;

                    case 'B':
                    currentPrefab = Acid2;
                        break;

                    case 'C':
                    currentPrefab = BgTile1;
                        break;

                    case 'D':
                    currentPrefab = BgTile2;
                        break;

                    case 'E':
                    currentPrefab = BgTile3;
                        break;

                    case 'F':
                    currentPrefab = BgTile4;
                        break;

                    case 'G':
                    currentPrefab = BgTile5;
                        break;

                    case 'H':
                    currentPrefab = BgTile6;
                        break;

                    case 'I':
                    currentPrefab = BgTile7;
                        break;

                    case 'J':
                    currentPrefab = Fence1;
                        break;

                    case 'K':
                    currentPrefab = Fence2;
                        break;

                    case 'L':
                    currentPrefab = Fence3;
                        break;

                    case 'M':
                    currentPrefab = Spike;
                        break;

                    case 'N':
                    currentPrefab = Tile1;
                        break;
                    case 'O':
                    currentPrefab = Tile2;
                        break;

                    case 'P':
                    currentPrefab = Tile3;
                        break;

                    case 'Q':
                    currentPrefab = Tile4;
                        break;

                    case 'R':
                    currentPrefab = Tile5;
                        break;

                    case 'W':
                    currentPrefab = Tile6;
                        break;

                    case 'V':
                    currentPrefab = Tile7;
                        break;

                    case '&':
                    currentPrefab = Tile8;
                        break;

                    case 'U':
                    currentPrefab = Tile9;
                        break;


                    case 'T':
                    currentPrefab = Tile10;
                        break;

                    case 'S':
                    currentPrefab = Tile11;
                        break;


                    case 'X':
                    currentPrefab = Tile12;
                        break;


                    case 'Y':
                    currentPrefab = Tile13;
                        break;

                    case 'Z':
                    currentPrefab = Tile14;
                        break;

                    case '!':
                    currentPrefab = Barrel1;
                        break;

                    case '@':
                    currentPrefab = Barrel2;
                        break;

                    case '#':
                    currentPrefab = Box;
                        break;

                    case '$':
                    currentPrefab = DoorLocked;
                        break;

                    case '%':
                    currentPrefab = DoorOpen;
                        break;

                    case '^':
                    currentPrefab = DoorUnlocked;
                        break;

                    case '*':
                    currentPrefab = Saw;
                        break;

                    case '(':
                    currentPrefab = Switch1;
                        break;

                    case ')':
                    currentPrefab = Switch2;
                        break;

                    case '_':
                    currentPrefab = Jelly3;
                        break;

                    case ' ':
                    continue;
 
                                            
                }

               currentPrefab = Instantiate(currentPrefab,new Vector3(j, -i), Quaternion.identity);

               currentPrefab.transform.SetParent(cellsContainer);
            }
        }

    }


    
}
