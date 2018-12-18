using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatus  {

    float AttackPower { get; }
	int Health { get;  }
    int MaxHealth { get; }

    void Damaged(float val);
    
}
