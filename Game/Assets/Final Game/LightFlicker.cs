using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light spotlight;
    public Transform player;

    [Header("Light Color")]
    public Color redColor = new Color(1f, 0.2f, 0.2f);  
    public Color normalColor = Color.white;
    public float noiseSpeed = 5f;

    [Header("Trigger")]
    public KeyCode resetKey = KeyCode.R;

    [Header("Audio")]

    public AudioSource chasingBGM;

    private bool isAlarm = true;
    private float noiseOffset = 0f;

    bool IsMonsterInRange() {
        GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("Monster");

        foreach (GameObject monster in allMonsters)
        {
            float distance = Vector3.Distance(transform.position, monster.transform.position);

            if (distance <= 10)
            {
                return true; 
            }
        }

        return false; 
    }

    void Start()
    {
       

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        spotlight.color = normalColor;
        spotlight.type = LightType.Spot;
    }

    void Update()
    {
        if (IsMonsterInRange())
        {
            noiseOffset += Time.deltaTime * noiseSpeed;


            float t = Mathf.PerlinNoise(noiseOffset, 0f);
            spotlight.color = Color.Lerp(normalColor, redColor, t);
            spotlight.intensity = Mathf.Lerp(0.5f, 2.5f, t);

            if (!chasingBGM.isPlaying) { 
                chasingBGM.Play();
            }
        }
        else {
            spotlight.color = normalColor;
            spotlight.intensity = 1f;
            if (chasingBGM.isPlaying)
            {
                chasingBGM.Stop();
            }
        }
    }
}
