using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField]
    private float distanceAway = 5;
    [SerializeField]
    private float distanceUp = 2;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform followXForm;

    private Vector3 velocityCamSmooth = Vector3.zero;
    [SerializeField]
    private float camSmoothDampTime = 0.1f;

    private Vector3 lookDir;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        followXForm = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 characterOffset = followXForm.position + new Vector3(0f, distanceUp, 0f);
        lookDir = characterOffset - this.transform.position;
        lookDir.y = 0;
        lookDir.Normalize();
        Debug.DrawRay(this.transform.position, lookDir, Color.green);

        targetPosition = characterOffset + followXForm.up * distanceUp - lookDir * distanceAway;
        Debug.DrawRay(followXForm.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(followXForm.position, -1f * followXForm.forward * distanceAway, Color.blue);
        Debug.DrawLine(followXForm.position, targetPosition, Color.magenta);

        //CompensateForWalls(this.transform.position, ref targetPosition);

        smoothPosition(this.transform.position, targetPosition);

        transform.LookAt(followXForm);
    }

    private void smoothPosition(Vector3 fromPos, Vector3 toPos)
    {
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
    }

    private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    {
        Debug.DrawLine(fromObject, toTarget, Color.cyan);
        RaycastHit wallHit = new RaycastHit();
        if (Physics.Linecast(fromObject, toTarget, out wallHit))
        {
            Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
            toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
        }
    }
}
