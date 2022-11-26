using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFunction : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.TryGetComponent(out PlayerController controller))
        {
            controller.Heal();
        }
    
    }

}
