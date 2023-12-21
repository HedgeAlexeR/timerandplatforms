using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public int playerDamage;
    public AudioSource hurtSoundEffect;
    //public string sceneName = "Level_1";
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        hurtSoundEffect = GameObject.Find("hurtSound").GetComponent<AudioSource>();
        //target.GetComponent<Transform>;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null) {
            
            Player player = other.GetComponent<Player>();
            player.TakeDamage(playerDamage);
            hurtSoundEffect.Play();
            if (player.health < 1)
            {
                EditorSceneManager.LoadScene("Level_1");
            }}
        if(other.tag == "Missile")
        {
            Destroy(other);
            Destroy(gameObject);
        }
    }

}
