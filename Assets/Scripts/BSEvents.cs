using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#region Shoot Events
public class BubbleShotEvent : UnityEvent {}
public class BubbleHitEvent : UnityEvent <BubbleEnums.BubbleColor, Vector3Int> {}
#endregion


