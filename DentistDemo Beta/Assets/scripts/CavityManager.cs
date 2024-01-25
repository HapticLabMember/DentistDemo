using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CavityManager : MonoBehaviour
{
    [SerializeField] private Transform cavity;

    private List<Cavity> cavities = new();
    public List<Transform> teeth = new();


    // Start is called before the first frame update
    void Start()
    {
        int[] cavityOnTeeth = new int[teeth.Count];
        for (int i = 0; i < teeth.Count; i++)
        {
            cavityOnTeeth[i] = Random.Range(0, 5);
            if (cavityOnTeeth[i] == 0)
            {
                Transform theCavity = Instantiate(cavity);
                theCavity.parent = teeth[i];
                if(i < 16)
                {
                    theCavity.localPosition = new Vector3(0, 0, 0.2f);
                } else
                {
                    theCavity.localPosition = new Vector3(0, 0, 0.2f);
                }

                Cavity newCavity = theCavity.GetComponent<Cavity>();
                cavities.Add(newCavity);
            }
        }
    }


    void CreateCavities()
    {
        //create condition for creating cavities instead of when play button pressed
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
