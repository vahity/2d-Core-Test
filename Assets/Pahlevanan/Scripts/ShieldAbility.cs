using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ShieldAbility : MonoBehaviour
{
   public void DisCol()
    {
        StartCoroutine(DisableObjects());
    }

    IEnumerator DisableObjects()
    {
        GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag("mane");

        foreach (GameObject obj in objectsToDisable)
        {
            Debug.Log(obj.name);    
            Collider2D collider = obj.GetComponent<Collider2D>();

            if (collider != null)
            {
                collider.enabled = false;
            }
        }

        yield return new WaitForSeconds(4f);

        foreach (GameObject obj in objectsToDisable)
        {
            Collider2D collider = obj.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }
        }
    }

}
