using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine : MonoBehaviour
{
    public bool upgrade = false;

    //how much mag count to add to the weapons current mag count
    public int magSize = 0;

    //multpied by the current reload time on the weapons script ex.) .5 == half the reload time
    public float reloadTime = 1;
}
