  using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Brawl_Out_Server
{
    class Player
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;

        public Player(int _id, string _username, Vector3 _spawnPosition)
        {
            id = _id;
            position = _spawnPosition;
            rotation = Quaternion.Identity;
        }
    }
}
