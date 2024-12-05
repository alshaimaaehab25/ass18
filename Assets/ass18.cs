using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ass18
{
    public struct Position
    {
        public float X, Y, Z;

        public Position(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void printPosition()
        {
            UnityEngine.Debug.Log($"X = {X}");
            UnityEngine.Debug.Log($" Y = {Y}");
            UnityEngine.Debug.Log($"{Z}");
        }
    }
    
}