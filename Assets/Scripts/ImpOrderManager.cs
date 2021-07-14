using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpOrderManager : MonoBehaviour
{
    public int assignedTouchID;
    public Vector2 touchStartPosition;

    public enum Order { up, down, left, right, stop }
    public Order currentOrder;
}
