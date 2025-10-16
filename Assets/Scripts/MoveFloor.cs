using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    [SerializeField] private float floorSpeed;

    private Material material;
    private Vector2 floorVector;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    private void Update()
    {
        floorVector = new Vector2(floorSpeed * Time.deltaTime, 0);
        material.mainTextureOffset += floorVector;
    }
}
