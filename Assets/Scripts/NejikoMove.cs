using UnityEngine;
using UnityEngine.InputSystem;

public class NejikoMove : MonoBehaviour
{
    // 目的：ねじ子の移動を制御するスクリプト
    // ねじ子の移動
    // -> 1mをmoveSpeed秒で移動する
    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private PlayerInput playerInput;
    //playerのキー入力を取得
    private bool isRightMove = false;
    //右の移動が処理されているか判断する変数
    private bool isLeftMove = false;
    //左の移動が処理されているか判断する変数
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
        transform.Translate(0, 0, movePower);

        // アニメーションの遷移
        if (movePower > 0)
        //movePowerが0より大きい場合は走るアニメーションに遷移させる
        {
            // コード上から走るアニメーションに遷移させる条件を満たす
            GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", false);
        }
        //playerのWASDをXとYに分割する
        //<Vector2=2次元
        //WASD -> Vector2(x,y)
        //W-> Vector2(0,1)
        //A-> Vector2(-1,0)
        //S-> Vector2(0,-1)
        //D->Vector2(1,0)
        //挑戦
        //キーボードが押されたらねじこが左右に移動する処理
        //1.Dキー、右矢印が押されたらねじこの現在の座標+new Vector3(1.0.0);
        //2.Aキー、左矢印が押されたらねじこの現在の座標+new Vector3(-1.0.0);
        //3.キーボードが一度押されたら離されるまで次の移動をしない
        //4.例えばDキ－が押された瞬間 x + 1 次のフレームからは移動しない
        if (playerInput.MoveKeyVector2.x >= 0.3f && isRightMove == false)
            //if　条件A && 条件B　両方の条件を満たしたときのみ以下の処理を行う == ←これ イコール
        {
            isRightMove = true;
            Debug.Log("右に移動");
            //ネジコの現在の座標+new Vector3(1.0.0)
            this.transform.position = this.transform.position + new Vector3(1,0,0);
        }else if(playerInput.MoveKeyVector2.x <= 0.3f)
        {
            isRightMove = false;
        }
        if (playerInput.MoveKeyVector2.x <= -0.3f && isLeftMove == false)
        {
            isLeftMove = true;
            //ネジコの現在の座標+new Vector3(-1.0.0)
            Debug.Log("左に移動");
            this.transform.position = this.transform.position + new Vector3(-1, 0, 0);
        }
        else if(playerInput.MoveKeyVector2.x >= 0.3f)
        {
            isLeftMove = false;
        }
    }
}