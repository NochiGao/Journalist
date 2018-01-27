using UnityEngine;

public class HideOnBeginPlay : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
