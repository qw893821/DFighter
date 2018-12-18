using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile {

	float Speed { get; set; }
    Vector3 Target { get; set; }
    float Duration { get; set; }
    float Selftimer { get; set; }
    float AttackPower { get; set; }

    bool End { get; set; }
    void Move();
}
