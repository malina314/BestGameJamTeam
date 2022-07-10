using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [HideInInspector]
    public RootController root;

    public virtual void EngageController()
    {
        Debug.Log(gameObject);
        gameObject.SetActive(true);
    }

    public virtual void DisengageController()
    {
        gameObject.SetActive(false);
    }

}

public abstract class BaseController<T> : BaseController where T : UIRoot 
{
    [SerializeField]
    protected T ui;
    public T UI => ui;
    public override void EngageController()
    {
        base.EngageController();
        ui.InitView();
    }
    public override void DisengageController()
    {
        base.DisengageController();
    }
}