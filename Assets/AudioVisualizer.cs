using UnityEngine;
using System.Collections;

public class AudioVisualizer : MonoBehaviour {
    public Light pointLight;
    public int channel;
    public AudioSource audio;
    public GameObject[] cubes; 
    private FFTWindow _fftWindow;
    private float[] _samples = new float[1024];
    
    // Use this for initialization
    void Start () {
        //channel to sample from, stereo music has 2 channels
        channel = 0;
        //what fft you want to use
        _fftWindow = FFTWindow.BlackmanHarris;
    }
	
	// Update is called once per frame
	void Update () {
        audio.GetSpectrumData(_samples, channel, _fftWindow);
        
        for (int i = 0; i < cubes.Length; i++)
        {
            //Debug.Log(_samples[i] + " @ cube:" + i );
            cubes[i].transform.localScale = new Vector3 (cubes[i].transform.localScale.x, _samples[i]*10, cubes[i].transform.localScale.z);
            pointLight.intensity = _samples[i]*100;
        }
    }
}
