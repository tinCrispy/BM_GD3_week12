using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion Information", fileName = "New Potion Info")]

public class PotionScript : ScriptableObject
{
    public string potionName;
    public string description;

    public Color potionColor;

    public int healthEffect;
}
