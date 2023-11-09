using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void PowerUpHandler();
    public event PowerUpHandler PowerUpPicked; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
            PowerUpPicked?.Invoke();
    }

}
