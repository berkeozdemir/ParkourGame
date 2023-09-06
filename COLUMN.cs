using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLUMN : MonoBehaviour
{
    public Transform checker;
    public LayerMask player_layer;
    public float radius;
    public Vector3 velocity;
    private bool broke = false;

    private void Update()
    {
        if (Physics.CheckBox(checker.position, new Vector3(radius, 2, radius), Quaternion.identity, player_layer))
        {
            broke = true;
        }
        if (broke)
        {
            velocity.z -= Time.deltaTime / 200;
            transform.Translate(velocity);
        }

    }

}
