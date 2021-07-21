using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 endPoint;
    [SerializeField] bool vertical;
    [SerializeField] LayerMask impsLayers;
    Vector3 startPoint;
    bool returning;
    public bool activated;

    private void Start()
    {
        startPoint = transform.position;
    }
    void Update()
    {
        if (activated)
        {
            if (!returning)
            {
                if (!vertical)
                    transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
                else
                    transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
                if ((!vertical && transform.position.x >= endPoint.x) || (vertical && transform.position.y >= endPoint.y))
                {
                    returning = true;
                    transform.position = endPoint;
                }
            }
            else
            {
                if (!vertical)
                    transform.position = transform.position - Vector3.right * speed * Time.deltaTime;
                else
                    transform.position = transform.position - Vector3.up * speed * Time.deltaTime;
                if ((!vertical && transform.position.x <= startPoint.x) || (vertical && transform.position.y <= startPoint.y))
                {
                    returning = false;
                    transform.position = startPoint;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger)
        {
            other.gameObject.transform.SetParent(transform);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger)
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
