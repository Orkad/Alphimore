using UnityEngine;
using System.Collections;
using System;

public enum ItemType
{
	QUEST = 0x0,
    USABLE = 0x1,
    HEAD = 0x2,
    BODY = 0x4,
    HAND = 0x8,
    FOOT = 0x16,
    WEAPON = 0x32

}

[Serializable]
public class Item{
	public string name;
	public string description;
	public Sprite sprite;
	public ItemType type;
}
