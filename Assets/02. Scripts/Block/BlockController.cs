using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;

    public void InitBlocks()
    {
        for(int i = 0; i < 9; i++)
        {
            GameObject blockObj = Instantiate(blockPrefab, transform);
            Block block = blockObj.GetComponent<Block>();
            block.InitMarker(i);
        }
    }
}
