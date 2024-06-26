using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    float speed = 0.05f;
    int directionX = 1;
    int directionY = 1;
    int directionZ = 1;

    // Update is called once per frame
    void Update()
    {
        // 현재 위치
        Vector3 position = transform.position;

        // 이동
        position.x += speed * directionX;
        position.y += speed / 5 * directionY;
        position.z += speed / 10 * directionZ;

        // 범위를 벗어나면 방향 전환
        if (position.x >= 12f)
            directionX = -1;
        else if (position.x <= -12f)
            directionX = 1;

        if (position.y >= 0f)
            directionY = -1;
        else if (position.y <= -2.5f)
            directionY = 1;

        if (position.z >= 20f)
            directionZ = -1;
        else if (position.z <= 10f)
            directionZ = 1;

        // 새로운 위치 설정
        transform.position = position;
    }
}
