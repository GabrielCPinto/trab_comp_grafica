namespace Data
{
    public class Voxel
    {
        public byte ID;
        public VoxelColor VoxelColor = WorldManager.Instance.WorldColors[0];

        public bool IsSolid
        {
            get
            {
                return ID != 0;
            }
        }
    }
}
