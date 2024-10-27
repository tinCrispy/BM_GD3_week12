using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

//    public GameObject potion;
    public Color color;




    public void thisPotion(PotionScript stats)
    {
        color = stats.potionColor;

    }
}
