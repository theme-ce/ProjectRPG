using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Destroy : MonoBehaviour
{
    public void DestroyParent()
    {
        GameObject parent = this.gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
