
using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Character:MonoBehaviour
{
    public string name;
    public CharacterInventory characterInventory;
    public CharacterEquipment equipement;
    public CharacterStats stats;
}

public class CharacterStats
{
    public int health;
    public int damages;
}

[Serializable]
public class CharacterEquipment
{
    public List<Item> items;
}

[Serializable]
public class CharacterInventory
{
    public List<Item> items;
}