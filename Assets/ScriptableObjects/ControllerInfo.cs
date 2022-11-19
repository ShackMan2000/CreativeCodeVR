using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ControllerInfo : ScriptableObject
{

    //get the position of the controller relative to the head


    public Vector3 controllerPosition;


    //save the last 10 seconds
    [SerializeField] List<Vector3> movements = new List<Vector3>();


    [ContextMenu("Remove")]
    public void AddMovementInfo(Vector3 m)
    {
        if (movements.Count >= 100)
        {
            movements.RemoveAt(0);  
        }

        movements.Add(m * 100f);
    }

    public Vector3 GetMovementLastSeconds(float seconds)
    {
        int entriesToGet = Mathf.RoundToInt(seconds * 10f);


        if (movements.Count < entriesToGet)
            entriesToGet = movements.Count;

        Vector3 movement = Vector3.zero;


        for (int i = movements.Count - 1; i > movements.Count - entriesToGet; i--)
        {
            movement+= movements[i];
        }



        return movement / entriesToGet;

    }


}
