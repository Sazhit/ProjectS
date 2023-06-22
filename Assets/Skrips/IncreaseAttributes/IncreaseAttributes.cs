using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttributes : MonoBehaviour
{
    [SerializeField] private float _increasedForce;

    [SerializeField] private Dash _dash;

    private float _originalDashForce;

    private void Start()
    {
        _originalDashForce = _dash.Force;

    }

    public void Attributes()
    {
        _dash.Force = _increasedForce;

        StartCoroutine(RestoreAttributesAfterDelay());
    }

    private IEnumerator RestoreAttributesAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        _dash.Force = _originalDashForce;
    }
}
