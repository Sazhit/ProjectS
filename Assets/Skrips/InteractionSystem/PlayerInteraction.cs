using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : Interaction
{
    [SerializeField] private Transform _detectionPoint;
    [SerializeField] private float _detectionRadius = 0.2f;
    [SerializeField] private LayerMask _detectionLayer;

    private void Update()
    {
        DetectAndInteractWithObject();
    }

    public bool InteractDownInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool InteractUpInput()
    {
        return Input.GetKeyUp(KeyCode.E);
    }

    public void DetectAndInteractWithObject()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_detectionPoint.position, _detectionRadius, _detectionLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (InteractDownInput())
            {
                Interaction interaction = hitCollider.GetComponent<Interaction>();
                if (interaction != null)
                {
                    interaction.Interact();
                }
            }

            if (InteractUpInput())
            {
                BoxInteracting doorInteracting = hitCollider.GetComponent<BoxInteracting>();
                if (doorInteracting != null)
                {
                    doorInteracting.Interact();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_detectionPoint.position, _detectionRadius);
    }
}
