using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In this class you add references to ui game objects like buttons etc.
/// </summary>
public class UIRoot : MonoBehaviour
{
    
    public virtual void InitView()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        gameObject.SetActive(false);
    }
}
