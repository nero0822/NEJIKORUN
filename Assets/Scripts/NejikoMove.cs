using UnityEngine;

public class NejikoMove : MonoBehaviour
{
    // 目的：ねじ子の移動を制御するスクリプト
    // ねじ子の移動
    // -> 1mをmoveSpeed秒で移動する
    [SerializeField]
    private float moveSpeed = 1.0f; 

    // ねじ子の移動は毎フレーム必ず行われる

    // データ型 = void(戻り値が無い時のメソッドのデータ型)
    void Update()
    {
        // 1mをmoveSpeed秒で移動するための移動量を計算
        float movePower = Time.deltaTime * moveSpeed;
        /*
        // 1秒間に60fps -> 10fps
        // 1fps -> 1m
        // 1秒間に60fps -> 1m*60fps = 60m
        // 1秒間に10fps -> 1m*10fps = 10m
        // Time.deltaTimeは前フレームからの経過時間を返す
        // 1秒間に60fps -> 1/60 
        // 1秒間に10fps -> 1/10
        // moveSpeed = 10;
        // 1秒間に60fps -> 1/60秒 / 10 = 1/600
        // 1秒間に10fps -> 0.1 / 10 = 1/100
        // Time.deltaTimeを使うとスペックに関係なく移動量を一定に出来る
        // Vector3 ( X, Y, Z)*/
        transform.Translate(0,0,movePower);
        
        // アニメーションの遷移
        if(movePower > 0)
        //movePowerが0より大きい場合は走るアニメーションに遷移させる
        {
            // コード上から走るアニメーションに遷移させる条件を満たす
            GetComponent<Animator>().SetBool("run", true);
        }else
        {
            GetComponent<Animator>().SetBool("run", false);
        }
    }
}