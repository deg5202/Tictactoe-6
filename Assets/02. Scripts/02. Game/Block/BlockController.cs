using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blockPrefabs;

    public delegate void OnBlockClicked(int index);

    public OnBlockClicked onBlockClicked;

    public void InitBlocks()
    {
        for (int i = 0; i < blockPrefabs.Length; i++)
            blockPrefabs[i].InitMarker(i, blockIndex =>
            {
                onBlockClicked?.Invoke(blockIndex);
            });
    }

    public void PlaceMarker(int blockIndex, Constants.PlayerType playerType)
    {
       switch(playerType)
        {
            case Constants.PlayerType.Player1:
                blockPrefabs[blockIndex].SetMarker(Block.MarkerType.O);
                break;
            case Constants.PlayerType.Player2:
                blockPrefabs[blockIndex].SetMarker(Block.MarkerType.X);
                break;
        }
    }
}