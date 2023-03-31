using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject[] t11, t12, t21, t22, t23, t31, t32, t33;
    float counter = 0;
    float cooldown = 21f * (1 / GameManager.terrainSpeed) - 0.01f;
    string terrainName, nameA = "1", nameB = "1";
    Dictionary<string, GameObject> nameMatch = new Dictionary<string, GameObject>();

    void Start()
    {
        for (int i = 0; i < t11.Length; i++)
        {
            string tempoName = "11-" + i.ToString();
            nameMatch.Add(tempoName, t11[i]);
        }

        for (int i = 0; i < t12.Length; i++)
        {
            string tempoName = "12-" + i.ToString();
            nameMatch.Add(tempoName, t12[i]);
        }

        for (int i = 0; i < t21.Length; i++)
        {
            string tempoName = "21-" + i.ToString();
            nameMatch.Add(tempoName, t21[i]);
        }

        for (int i = 0; i < t22.Length; i++)
        {
            string tempoName = "22-" + i.ToString();
            nameMatch.Add(tempoName, t22[i]);
        }

        for (int i = 0; i < t23.Length; i++)
        {
            string tempoName = "23-" + i.ToString();
            nameMatch.Add(tempoName, t23[i]);
        }

        for (int i = 0; i < t31.Length; i++)
        {
            string tempoName = "31-" + i.ToString();
            nameMatch.Add(tempoName, t31[i]);
        }

        for (int i = 0; i < t32.Length; i++)
        {
            string tempoName = "32-" + i.ToString();
            nameMatch.Add(tempoName, t32[i]);
        }

        for (int i = 0; i < t33.Length; i++)
        {
            string tempoName = "33-" + i.ToString();
            nameMatch.Add(tempoName, t33[i]);
        }
    }

    void Update()
    {
        if (counter > cooldown)
        {
            int randomNumber = Random.Range(0, t11.Length);
            nameA = Random.Range(1, int.Parse(nameB) + 2).ToString();
            //nameA = Random.Range(1, 3).ToString();

            if (nameA == "1")
            {
                nameB = Random.Range(1, 3).ToString();
            }
            else nameB = Random.Range(1, 4).ToString();

            terrainName = nameA + nameB + "-" + randomNumber.ToString();
            Debug.Log(terrainName);

            if (nameMatch.TryGetValue(terrainName, out GameObject prefab))
            {
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                counter = 0;
            }
        }

        counter += Time.deltaTime;
    }
}
