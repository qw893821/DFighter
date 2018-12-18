using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CharAction
{
    public struct SpeedStruct {
        public float speed { get; set; }
        float speedInRate { get; set; }
        float speedDeRate { get; set; }
        float maxSpeed { get; set; }
        float minSpeed { get; set; }//current plan
        public SpeedStruct(float speed, float sin, float sde, float max,float min) : this()
        {
            this.speed = speed;
            speedInRate = sin;
            speedDeRate = sde;
            maxSpeed = max;
            minSpeed = min;
        }

        public bool Compair(){
            if (speed < maxSpeed)
            {
                return true;
            }
            else return false;
        }

        public float speedMani(float inVal)
        {
            if (inVal != 0)
            {
                if (Compair())
                {
                    this.speed += speedInRate * Time.deltaTime;
                    return this.speed;
                }
                else { return maxSpeed; }
            }
            else if (inVal == 0 && this.speed > minSpeed)
            {
                this.speed -= speedDeRate * Time.deltaTime;
                return this.speed;
            }
            else { return minSpeed; }   
        }
    }

    public interface ICharAction
    {
        SpeedStruct XSpeed { get; set; }
        SpeedStruct YSpeed { get; set; }
        bool Move();
        bool Attack();
        bool Idle();
    }
}
