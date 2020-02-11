using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    public float speed = 3.0f;
    public const float basespeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);


    }

    private void OnSpeedChanged(float value)
    {
        speed = basespeed * value;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(4, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            _enemy.GetComponent<WanderingAI>().speed = speed;


        }
    }
}
