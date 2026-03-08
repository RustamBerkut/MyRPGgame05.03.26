using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject attackHandPoint;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnAttack();
        }
    }
    private void OnAttack()
    {

    }
}
