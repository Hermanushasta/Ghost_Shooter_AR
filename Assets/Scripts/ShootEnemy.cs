using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootEnemy : MonoBehaviour {
	public int distanceOfRay = 20; //jarak raycast, atau titik cursor dari camera ke objek
	private RaycastHit hit; //untuk menerima objek apa yang terkena raycast	
	public int nilaiscore;
	public Text scoretampil;
	public AudioClip deathAudio;
	private AudioSource enemyAudio;

	// Update is called once per frame
	void Start()
    {
		nilaiscore = 0;
		scoretampil.text = "Skor : " + nilaiscore;
		enemyAudio = GetComponent<AudioSource>();

	
	}
	void Update(){
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //mengeluarkan raycast dari titik tengah camera
		
		//Click Input
		Debug.DrawLine (transform.position, hit.point,Color.red);
		if(Physics.Raycast(ray, out hit, distanceOfRay)){ //apabila ada sesuatu dari raycast
			if(Input.GetButtonDown("Fire1") && hit.transform.CompareTag("Enemy")){ //apabila sesuatu itu adalah tag enemy dan kita menekan	tombol	
				Destroy(hit.transform.gameObject);
				nilaiscore += 1;
				AudioManager.instance.PlayHitEffect();
				scoretampil.text = "Skor : " + nilaiscore;//destroy sesuatu itu
			}
		}		
	}
}