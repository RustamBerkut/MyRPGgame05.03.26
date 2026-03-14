using UnityEngine;

public class SelfDestroer : MonoBehaviour
{
    [SerializeField]
    private byte timerToDeath;
    void Start()
    {
        Destroy(gameObject, timerToDeath);
    }

}
