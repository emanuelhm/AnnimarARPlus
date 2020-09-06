using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public float Quantity;

    public Transform Object;

    public void MoveUp()
    {
        var x = Object.localPosition.x;
        var y = Object.localPosition.y;
        var z = Object.localPosition.z;

        y += Quantity;

        Object.localPosition = new Vector3(x, y, z);
    }

    public void MoveDown()
    {
        var x = Object.localPosition.x;
        var y = Object.localPosition.y;
        var z = Object.localPosition.z;

        y -= Quantity;

        Object.localPosition = new Vector3(x, y, z);
    }
}
