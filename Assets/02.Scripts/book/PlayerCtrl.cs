using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float mx = 0.0f;

    private Transform tr;

    // 이동속도 변수
    public float moveSpeed = 10.0f;

    // 회전속도 변수
    public float rootSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 스크립트가 실행된 후 처음 수행되는 Start 함수에서 Transform 컴포넌트 할당
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // 키보드의 A, D 또는 화살표 Left, Right를 눌렀을 때 -1부터 +1까지의 값을 반환
        v = Input.GetAxis("Vertical");   // 키보드의 W, D 또는 화살표 Up, Down을 눌렀을 때 -1부터 +1까지의 값을 반환
        mx = Input.GetAxis("Mouse X");

        Debug.Log("H=" + h.ToString());
        Debug.Log("V=" + v.ToString());
        Debug.Log("MX=" + mx.ToString());

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        tr.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);

        tr.Rotate(Vector3.up * Time.deltaTime * rootSpeed * mx);
    }
}
