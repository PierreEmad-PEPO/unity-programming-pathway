using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    Material material;

    private Vector3 scale = Vector3.one;
    private Vector3 rotation = Vector3.zero;
    private float horizontalInput, verticalInput;
    private Color curColor, nxtColor;

    private float transitionTimer = 0f;
    private float transitionDuration = 5f;

    void Start()
    {
        //transform.position = new Vector3(3, 4, 1);
        //transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;
        curColor = material.color;
        nxtColor = new Color(0, 0, 0, 0);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        scale.x += horizontalInput * Time.deltaTime;
        scale.y += verticalInput * Time.deltaTime;
        if (scale.x < 1) scale.x = 1;
        if (scale.y < 1) scale.y = 1;

        rotation.x += verticalInput * Time.deltaTime / 2;
        rotation.y += horizontalInput * Time.deltaTime / 2;

        transform.localScale = scale;
        transform.Rotate(rotation);

        if (rotation.x > 0) rotation.x -= Time.deltaTime * 0.1f;
        if (rotation.x < 0) rotation.x += Time.deltaTime * 0.1f;

        if (rotation.y > 0) rotation.y -= Time.deltaTime * 0.1f;
        if (rotation.y < 0) rotation.y += Time.deltaTime * 0.1f;


        transitionTimer += Time.deltaTime;
        if (transitionTimer >= transitionDuration)
        {
            curColor = nxtColor;
            nxtColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
            transitionTimer = 0f;
        }

        Color lerpedColor = Color.Lerp(curColor, nxtColor, transitionTimer / transitionDuration);
        material.color = lerpedColor;
    }
}
