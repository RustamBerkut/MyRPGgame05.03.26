using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float Velocity;
    public float MinDistance;

    private void Start()
    {
        Invoke(nameof(SetupPlayerInCamera), 1f);
    }
    private void SetupPlayerInCamera()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (Target == null)
        {
            return;
        }

        var targetPos = Target.transform.position + Offset;

        if (Vector3.Distance(transform.position, targetPos) < MinDistance)
        {
            return;
        }
        var newPos = Vector3.Lerp(transform.position, targetPos, Velocity * Time.fixedDeltaTime);
        transform.Translate(transform.InverseTransformPoint(newPos));
    }
}
