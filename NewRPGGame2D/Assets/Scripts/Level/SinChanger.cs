using UnityEngine;

public class SinChanger : MonoBehaviour
{
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 1f;

    float x;
    float y;
    float z;

    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    private void Update()
    {
        float y1 = transform.position.y;

        // Sine wave for vertical movement
        y1 = Mathf.Sin(Time.time * frequency) * amplitude;

        // Cosine wave for horizontal movement
        //x = Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(x, y + y1, z);
    }
}
