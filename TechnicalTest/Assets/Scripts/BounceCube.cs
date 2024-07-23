using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCube : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] Vector3 direction;
    [SerializeField] private Material[] cubeMaterials;
    [SerializeField] private int materialIndex = 0;
    [SerializeField] private Renderer cubeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        direction = Random.onUnitSphere;
        direction.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        Vector3 normal = collision.GetContact(0).normal;
        direction = Vector3.Reflect(direction, normal);
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {

        if (cubeMaterials.Length > 0)
        {
            materialIndex = materialIndex + 1;
            if (cubeMaterials.Length == materialIndex)
            {
                materialIndex = 0;
            }
            cubeRenderer.material = cubeMaterials[materialIndex];
        }
    }
}
