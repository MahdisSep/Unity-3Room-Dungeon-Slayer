using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
   [SerializeField] private GameObject[] enemies ; //list of enemies in this room
   private Vector3[] initialPos; // starting position of enemies

   private void Awake()
   {
    initialPos = new Vector3[enemies.Length];
    for (int i = 0; i < enemies.Length ; i++)
    {
        if(enemies[i] != null)
            initialPos[i] = enemies[i].transform.position;
    }
   }
   public void ActivateRoom (bool _status)
   {
    //activate or deactivate the enemies
    for (int i = 0; i < enemies.Length ; i++)
    {
        if(enemies[i] != null)
        {
            enemies[i].SetActive(_status); //active the enemies in the current room
            enemies[i].transform.position = initialPos[i];

        }
    }
   }
}
