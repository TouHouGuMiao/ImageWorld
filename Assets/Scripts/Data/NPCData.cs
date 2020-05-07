using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData
{
    public enum IconType
    {
        scene,
        characer,
        moster,
    }
    public int id;
    public IconType iconType = IconType.characer;
    public string npcName;
    public string npcDes;
}
