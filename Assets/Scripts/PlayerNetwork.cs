using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private MonoBehaviour[] scriptsToIgnore;


    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        Initialize();
    }
    void Initialize()
    {
        if (photonView.isMine)
        {

        }
        else
        {
            playerCamera.SetActive(false);
            groundCheck.SetActive(false);
            foreach(MonoBehaviour item in scriptsToIgnore)
            {
                item.enabled = false;
            }
        }
    }
}
