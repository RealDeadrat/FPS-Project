using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=au2Fyq9wX48

public class Teleport : MonoBehaviour
{
    private RaycastHit lastRaycastHit;
    public AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    private GameObject GetLookedAtObject()
    {
        Vector3 origin = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float range = 1000;

        if (Physics.Raycast(origin, direction, out lastRaycastHit, range))
            return lastRaycastHit.collider.gameObject;
        else
            return null;

    }

    private void TeleportToLookAt()
    {
        transform.position = lastRaycastHit.point + lastRaycastHit.normal * 2;
        if (audioClip != null)
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
            if (GetLookedAtObject() != null)
                TeleportToLookAt();
    }

}
