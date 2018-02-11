using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour {
    public float onTime;
    public float offTime;
    private float timer;
    private Renderer laserRenderer;
    private Light laserLight;

    private void Awake()
    {
        laserRenderer = GetComponent<Renderer>();
        laserLight = GetComponent<Light>();
        timer = 0f;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (laserRenderer.enabled && timer >= onTime)
            SwitchBeam();
        if (!laserRenderer.enabled && timer >= offTime)
            SwitchBeam();
	}

    void SwitchBeam()
    {
        timer = 0f;
        laserRenderer.enabled = !laserRenderer.enabled;
        laserLight.enabled = !laserLight.enabled;
    }
}
