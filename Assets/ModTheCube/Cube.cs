using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.5f;


        StartCoroutine(ChangeColorPeriodically());

        // Material material = Renderer.material;

        // material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(0.0f , 0.0f, 7.0f * Time.deltaTime);
    }

    IEnumerator ChangeColorPeriodically()
    {
        Material material = Renderer.material;

        while (true)
        {
            Color startColor = material.color;
            Color targetColor = new Color(Random.value, Random.value, Random.value, 1.0f);

            float duration = 1.0f; // Set the duration for the color change

            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                material.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            // Ensure the final color value
            material.color = targetColor;

            yield return new WaitForSeconds(1.0f); // Wait for 2 seconds before changing color again
        }

        
    }
}
