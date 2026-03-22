using UnityEngine;

public class SelfDestroer : MonoBehaviour
{
    [SerializeField]
    private float timerToDeath;
    void Start()
    {
        Destroy(gameObject, timerToDeath);
    }

}
