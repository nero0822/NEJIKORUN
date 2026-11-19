using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputAction JumpAction;
    private InputAction MoveAction;

    public Vector2 MoveKeyVector2 = Vector2.zero;
    // 左右のキーがどのくらい押されているのかの値
    private void Start()
    {
        JumpAction = InputSystem.actions.FindAction("Jump");
        MoveAction = InputSystem.actions.FindAction("Move");
    }
    //1f毎に処理を行う関数
    private void Update()
    {
        if (JumpAction.triggered)
        {
            Debug.Log("じゃーんぷしたよ!");
        }
        //移動の入力を表示
        //左右上下キーの入力Vector2(2次元方向)で出力
        MoveKeyVector2 = MoveAction.ReadValue<Vector2>();
 
        }
    }

