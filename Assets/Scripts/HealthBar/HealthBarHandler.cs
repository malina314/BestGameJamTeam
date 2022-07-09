using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarHandler : MonoBehaviour
{
    private Transform bar;
    private float lastHealthRatio;

    [SerializeField]
    private float lerpDuration;
    [SerializeField]
    private float healthBarRatio;

    // Start is called before the first frame update
    void Start()
    {
        Entity parentEntity = gameObject.transform.parent.GetComponent<Entity>();
        parentEntity.OnHealthChange += UpdateBar;
        bar = gameObject.transform.Find("Bar");
        lastHealthRatio = (float)parentEntity.Health / (float)parentEntity.MaxHealth;
        healthBarRatio = 1;
    }

    void UpdateBar(Entity sender)
    {
        float newHealthRatio = (float)sender.Health / (float)sender.MaxHealth;
        StartCoroutine(Lerp(lastHealthRatio, newHealthRatio));
        lastHealthRatio = newHealthRatio;
    }

    IEnumerator Lerp(float startHealthRatio, float endHealthRatio)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            healthBarRatio = Mathf.Lerp(startHealthRatio, endHealthRatio, timeElapsed / lerpDuration);
            setHealthBar(healthBarRatio);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        healthBarRatio = endHealthRatio;
    }

    private void setHealthBar(float ratio)
    {
        Vector3 newScale = new Vector3();
        newScale.x = ratio;
        newScale.y = 1f;
        newScale.z = 1f;
        bar.localScale = newScale;
    }
}
