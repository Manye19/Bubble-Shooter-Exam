using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameBubbles : MonoBehaviour
{
    public List<GameObject> gameBubbles;

    private void Start()
    {
        for (int i = 0; i < gameBubbles.Count; i++)
        {
            if (i >= gameBubbles.Count)
            {
                return;
            }
            else gameBubbles[i].transform.position = gameBubbles[i + 1].transform.position;
        }
    }
}