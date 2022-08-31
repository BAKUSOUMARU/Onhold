using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGimmick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(CharacterMove._battery <= 80)
            {
                CharacterMove._battery += 20;
            }else if (CharacterMove._battery <= 100)
            {
                CharacterMove._battery += 100 - CharacterMove._battery;
            }
            Destroy(this.gameObject);
        }
    }
}
