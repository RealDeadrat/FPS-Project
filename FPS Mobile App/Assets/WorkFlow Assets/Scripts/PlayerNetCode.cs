using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetCode : NetworkBehaviour
{
    public GameObject PlayerUnitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer == false)
        {
            return;
        }

        //Instantiate(PlayerUnitPrefab);

        CmdSpawnVoodoo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command]
    void CmdSpawnVoodoo ()
    {
       GameObject go = Instantiate(PlayerUnitPrefab);


        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
