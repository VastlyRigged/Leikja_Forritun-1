using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rename : PropertyAttribute
{
    public string NewName { get; private set; }
    public Rename(string name)
    {
        NewName = name;
    }
}
