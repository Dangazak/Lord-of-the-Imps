using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    [SerializeField] LayerMask interactableObjects;
    [SerializeField] List<ImpOrderManager> imps = new List<ImpOrderManager>();
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
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo, 50, interactableObjects))
        {
            if (hitinfo.collider.gameObject.layer == Constants.BIG_IMPS_LAYER
            || hitinfo.collider.gameObject.layer == Constants.FLYING_IMPS_LAYER
            || hitinfo.collider.gameObject.layer == Constants.NORMAL_IMPS_LAYER
            || hitinfo.collider.gameObject.layer == Constants.SMALL_IMPS_LAYER)
            {
                ImpOrderManager tempImp = hitinfo.collider.gameObject.GetComponent<ImpOrderManager>();
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

                imps[i].currentOrder = ChooseOrder(imps[i].touchStartPosition, touch.position);
                imps.Remove(imps[i]);
            }
        }
    }
    ImpOrderManager.Order ChooseOrder(Vector2 startPosition, Vector2 endPosition)
    {
        Vector2 touchMovement = endPosition - startPosition;
        if (touchMovement.magnitude < touchOffset)
        {
            return ImpOrderManager.Order.stop;
        }
        else if (touchMovement.x > 0 && touchMovement.x >= touchMovement.y)
        {
            return ImpOrderManager.Order.right;
        }
        else if (touchMovement.x < 0 && touchMovement.x <= touchMovement.y)
        {
            return ImpOrderManager.Order.left;
        }
        else if (touchMovement.y > 0)
        {
            return ImpOrderManager.Order.up;
        }
        else
        {
            return ImpOrderManager.Order.down;
        }
    }
}
