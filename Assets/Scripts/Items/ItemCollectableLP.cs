using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableLP : ItemCollectableBase
{
    public Collider2D collider;

    /*private void PlayLPVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.LP, gameObject.transform.position);
    }*/
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddLP();
        collider.enabled = false;

    }
}
