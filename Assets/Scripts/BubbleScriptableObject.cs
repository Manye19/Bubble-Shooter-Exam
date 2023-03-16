using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bubble Scriptable Object", menuName = "ScriptableObjects/Bubble")]
public class BubbleScriptableObject : ScriptableObject
{
    public string bubbleName;
    public Sprite bubbleSprite;
    [SerializeField]
    private BubbleEnums.BubbleColor bubbleColor;
}
