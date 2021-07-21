using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] MovingPlatform[] platforms;
    [SerializeField] float pressedMovement;
    [SerializeField] LayerMask impsLayers;
    [SerializeField] GameObject sprite;
    Vector3 startPosition;
    int impsIn;

    private void Start()
    {
        startPosition = sprite.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger)
        {
            impsIn++;
            sprite.transform.position += Vector3.down * pressedMovement;
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].activated = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger)
        {
            impsIn--;
            if (impsIn == 0)
            {
                sprite.transform.position = startPosition;
                for (int i = 0; i < platforms.Length; i++)
                {
                    platforms[i].activated = false;
                }
            }
        }
    }
}
