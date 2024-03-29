using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour
{
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;
    
    // 現在のキャンディのストック数
    int candy = DefaultCandyAmount;
    // ストック回復までの残り秒数
    int counter;
    
    GUIStyle style;
    
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 60;
    }
    
    public void ConsumeCandy()
    {
        if (candy > 0){
            candy--;
        }
    }
    
    public int GetCandyAmount()
    {
        return candy;
    }
    
    public void AddCandy(int amount)
    {
        candy += amount;
    }
    
    void OnGUI()
    {
        GUI.color = Color.black;
        
        // キャンディのストック数を表示
        string label = "Candy : " + candy;
        
        // 回復カウントをしている時だけ秒数を表示
        if(counter > 0) label = label + "（ " + counter + " s）";
        
        GUI.Label(new Rect(0, 0, 100, 30), label, style);
    }
    
    void Update()
    {
        // キャンディのストックがデフォルトより少なく、
        // 回復カウントをしていない場合、カウントをスタートさせる
        if(candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy());
        }
    }
    
    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;
        
        // 1秒ずつカウントを進める
        while(counter > 0)
        {
            // yieldでreturnしたものに応じて、一定時間以降の処理が保留される
            // ここではcounterを減らす処理を1秒間保留している
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        
        candy++;
    }
}
