using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab; // Zemin prefab'ý
    public float interval = 2f;     // Oluþum aralýðý
    public int numberOfGrounds = 10; // Oluþturulacak zemin sayýsý
    public float xRange = 1.5f;     // X pozisyonu için rastgele aralýk

    private float currentYPosition = 0f;

    void Start()
    {
        GenerateGrounds();
    }

    void GenerateGrounds()
    {
        for (int i = 0; i < numberOfGrounds; i++)
        {
            // X pozisyonunu rastgele belirle
            float randomXPosition = Random.Range(-xRange, xRange);

            // Yeni zemin oluþtur
            GameObject newGround = Instantiate(groundPrefab, new Vector3(randomXPosition, currentYPosition, 0), Quaternion.identity);

            // Yüksekliði artýr
            currentYPosition += interval;

            // Eðer isterseniz, yeni zemini bu GameObject'in çocuðu yapabilirsiniz
            newGround.transform.parent = this.transform;
        }
    }
}
