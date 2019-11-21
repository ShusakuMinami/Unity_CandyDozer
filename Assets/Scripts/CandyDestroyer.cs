using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyHolder candyHolder;
    public int reward;
    public GameObject effectPrefab;
    public Vector3 effectRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Candy")
        {
            // 指定数だけキャンディのストックを増やす
            candyHolder.AddCandy(reward);
            
            // オブジェクトを削除
            Destroy(other.gameObject);
            
            if(effectPrefab != null)
            {
                // candyのポジションにエフェクトを生成
                Instantiate(
                    effectPrefab,
                    other.transform.position,
                    Quaternion.Euler(effectRotation)
                    );
            }
        }
    }
}
