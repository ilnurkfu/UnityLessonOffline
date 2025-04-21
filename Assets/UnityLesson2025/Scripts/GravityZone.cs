using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    [SerializeField] private bool isInvertedGravity;

    [SerializeField] private float gravityStrenght;

    [SerializeField] private List<PlayerController> playerControllers;

    private void Update()
    {
        Vector3 gravityDirection = isInvertedGravity ? Vector3.up : Vector3.down;

        for(int i = 0; i < playerControllers.Count; i++)
        {
            playerControllers[i].AddGravity(gravityDirection * gravityStrenght, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            if(playerControllers.Contains(playerController) == false)
            {
                playerControllers.Add(playerController);
                playerController.UseGravity(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var playerController))
        {
            playerController.UseGravity(true);
            playerControllers.Remove(playerController);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < playerControllers.Count; i++)
        {
            playerControllers[i].UseGravity(true);
        }

        playerControllers.Clear();
    }
}
