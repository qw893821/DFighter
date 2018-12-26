using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Character",menuName ="Character")]
public class Characters : ScriptableObject {

    public string CharName;
    public float AttackPower;
    public int Health;
    public int MaxHealth;

}
