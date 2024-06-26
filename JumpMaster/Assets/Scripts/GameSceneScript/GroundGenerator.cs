using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject groundPrefab; // Zemin prefab'�
    public float interval = 2f;     // Olu�um aral���
    public int numberOfGrounds = 10; // Olu�turulacak zemin say�s�
    public float xRange = 1.5f;     // X pozisyonu i�in rastgele aral�k

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

            // Yeni zemin olu�tur
            GameObject newGround = Instantiate(groundPrefab, new Vector3(randomXPosition, currentYPosition, 0), Quaternion.identity);

            // Y�ksekli�i art�r
            currentYPosition += interval;

            // E�er isterseniz, yeni zemini bu GameObject'in �ocu�u yapabilirsiniz
            newGround.transform.parent = this.transform;
        }
    }
}
