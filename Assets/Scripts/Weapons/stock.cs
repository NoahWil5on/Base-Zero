using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stock : MonoBehaviour
{
    public bool upgrade = false;
    //how much does the accuracy change? Number is added to the weapons current accuracy. Bigger numbers are more accuracte
    public int accuracy = 0;

    //multiplied by the current recoil... on the weapon script "recoil" is the number of angles of recoil
    public float recoil = 1;

}
