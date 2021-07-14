using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpMovement : MonoBehaviour
{
    [SerializeField] float speed;
    enum State { walking, jumping, falling, stopped }
    State currentState = State.falling;

    void Update()
    {

    }
}
