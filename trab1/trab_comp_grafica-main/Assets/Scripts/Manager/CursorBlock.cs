using System;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Manager
{
    public class CursorBlock : MonoBehaviour
    {
        private WorldManager _worldManager;
        private Vector3 Position { get; set; }
        public VoxelColor voxelColor;

        private void Start()
        {
            Position = new Vector3(5, 20, 5);
            _worldManager = WorldManager.Instance;
            voxelColor = _worldManager.WorldColors[0];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(z:1);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(z:-1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(x:1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(x:-1);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Move(y:1);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Move(y:-1);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _worldManager.AddBlock(Position, new Voxel() {ID = 1, VoxelColor = voxelColor});
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                _worldManager.RemoveBlock(Position);
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                voxelColor = new VoxelColor() {color = Color.blue};
                Move();
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                voxelColor = new VoxelColor() {color = Color.red};
                Move();
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                voxelColor = new VoxelColor() {color = Color.green};
                Move();
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                voxelColor = new VoxelColor() {color = Color.yellow};
                Move();
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                voxelColor = new VoxelColor() {color = Color.white};
                Move();
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                voxelColor = new VoxelColor() {color = Color.black};
                Move();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _worldManager.ClearBlocks();
                Move();
            }
        }
        
        private void Move(int x = 0, int y = 0, int z = 0)
        {
            Position = new Vector3(Position.x + x, Position.y + y, Position.z + z);
            
            var dict = new Dictionary<Vector3, Voxel> { { Position, new Voxel() {ID = 1, VoxelColor = voxelColor} } };
            _worldManager.RenderBlocks(dict);
        }
    }
}