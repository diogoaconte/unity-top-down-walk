using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject go;
    public CamFollowMode camFollowMode = CamFollowMode.Delayed;
    public float smoothTimeDelayed = DEFAULT_DELAYED_SMOOTH_TIME;
    public float maxSpeedDelayed = DEFAULT_DELAYED_MAX_SPEED;
    public float velocityCamFactorAhead = DEFAULT_AHEAD_VELOCITY_CAM_FACTOR;
    
    private static float DEFAULT_DELAYED_SMOOTH_TIME = 0.06f;
    private static float DEFAULT_DELAYED_MAX_SPEED = 10f;
    private static float DEFAULT_AHEAD_VELOCITY_CAM_FACTOR = 0.02f;
    private Vector2 velocity;
    void Start()
    {
        velocity = Vector2.zero;
        UpdateCamPositionPrecise();
    }

    void LateUpdate()
    {
        switch(camFollowMode){
            case CamFollowMode.Delayed:
                UpdateCamPositionDelayed();
                break;            
            case CamFollowMode.Ahead:
                UpdateCamPositionAhead();
                break;
            default:
                UpdateCamPositionPrecise();
                break;
        }
    }

    private void UpdateCamPositionDelayed()
    {
        var interpolated = Vector2.SmoothDamp(
            transform.position,
            new Vector2(go.transform.position.x, go.transform.position.y),
            ref velocity,
            smoothTimeDelayed,
            maxSpeedDelayed
        );

        transform.position = new Vector3(interpolated.x, interpolated.y, transform.position.z);
    }

    private void UpdateCamPositionAhead()
    {
        var velocityRescaled = go.GetComponent<Rigidbody2D>().velocity * velocityCamFactorAhead;
        Vector3 velocityOffset = new Vector3(velocityRescaled.x, velocityRescaled.y, 0f);
        transform.position = new Vector3(
            go.transform.position.x,
            go.transform.position.y,
            transform.position.z) 
            + velocityOffset;
    }

    private void UpdateCamPositionPrecise()
    {
        transform.position = new Vector3(
            go.transform.position.x,
            go.transform.position.y,
            transform.position.z
        );
    }

    public enum CamFollowMode {
        Delayed,
        Ahead,
        Precise
    }
}
