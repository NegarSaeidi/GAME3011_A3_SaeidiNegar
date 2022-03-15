using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesMovement : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }
}
