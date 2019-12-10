using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject gameObject;

    public void Die()
    {
        Destroy(gameObject);
    }
}
