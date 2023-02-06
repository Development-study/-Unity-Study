using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float mx = 0.0f;

    private Transform tr;

    // �̵��ӵ� ����
    public float moveSpeed = 10.0f;

    // ȸ���ӵ� ����
    public float rootSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        // ��ũ��Ʈ�� ����� �� ó�� ����Ǵ� Start �Լ����� Transform ������Ʈ �Ҵ�
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // Ű������ A, D �Ǵ� ȭ��ǥ Left, Right�� ������ �� -1���� +1������ ���� ��ȯ
        v = Input.GetAxis("Vertical");   // Ű������ W, D �Ǵ� ȭ��ǥ Up, Down�� ������ �� -1���� +1������ ���� ��ȯ
        mx = Input.GetAxis("Mouse X");

        Debug.Log("H=" + h.ToString());
        Debug.Log("V=" + v.ToString());
        Debug.Log("MX=" + mx.ToString());

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(�̵����� * �ӵ� * ������ * Time.deltaTime, ������ǥ)
        tr.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);

        tr.Rotate(Vector3.up * Time.deltaTime * rootSpeed * mx);
    }
}
