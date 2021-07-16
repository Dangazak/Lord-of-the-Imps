using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    [SerializeField] LayerMask interactableObjects;
    [SerializeField] List<ImpMovement> imps = new List<ImpMovement>();
    [SerializeField] float touchOffset;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches[i].phase == TouchPhase.Began)
                {
                    FindTargetWithRaycast(Input.touches[i]);
                }
                else if (Input.touches[i].phase == TouchPhase.Ended)
                {
                    GiveOrderToImp(Input.touches[i]);
                }
            }
        }
    }
    void FindTargetWithRaycast(Touch touch)
    {
        Debug.Log("toque");
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit2D hitinfo = Physics2D.Raycast(ray.origin, ray.direction, 500, interactableObjects);

        if (hitinfo)
        {
            if (hitinfo.collider.gameObject.layer == Constants.BIG_IMPS_LAYER
            || hitinfo.collider.gameObject.layer == Constants.FLYING_IMPS_LAYER
            || hitinfo.collider.gameObject.layer == Constants.NORMAL_IMPS_LAYER
            || hitinfo.collider.gameObject.layer == Constants.SMALL_IMPS_LAYER)
            {
                ImpMovement tempImp = hitinfo.collider.gameObject.GetComponent<ImpMovement>();
                imps.Add(tempImp);
                tempImp.assignedTouchID = touch.fingerId;
                tempImp.touchStartPosition = touch.position;
            }
            else if (hitinfo.collider.gameObject.layer == Constants.PORTALS_LAYER)
            {
                hitinfo.collider.gameObject.GetComponent<Portal>().SpawnImp();
            }
        }
    }
    void GiveOrderToImp(Touch touch)
    {
        for (int i = 0; 0 < imps.Count; i++)
        {
            if (imps[i].assignedTouchID == touch.fingerId)
            {
                if (imps[i].canRecieveOrders)
                    ChooseOrder(imps[i].touchStartPosition, touch.position, imps[i]);
                imps.Remove(imps[i]);
            }
        }
    }
    void ChooseOrder(Vector2 startPosition, Vector2 endPosition, ImpMovement imp)
    {
        Vector2 touchMovement = endPosition - startPosition;
        if (touchMovement.magnitude < touchOffset)
        {
            if (imp.currentState != ImpMovement.State.stopped)
            {
                imp.Jump();
                Debug.Log("click jump");
            }
            else
            {
                imp.Move(!imp.flipped);
                Debug.Log("click move");
            }
        }
        else if (touchMovement.x > 0 && touchMovement.x >= touchMovement.y)
        {
            imp.Move(true);
            Debug.Log("move right");
        }
        else if (touchMovement.x < 0 && touchMovement.x <= touchMovement.y)
        {
            imp.Move(false);
            Debug.Log("move left");
        }
        else if (touchMovement.y > 0)
        {
            imp.Jump();
            Debug.Log("jump");
        }
        else
        {
            imp.Stop();
            Debug.Log("stop");
        }
    }
}
