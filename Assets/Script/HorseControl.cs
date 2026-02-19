using UnityEngine;
using UnityEngine.UI;

public class HorseControl : MonoBehaviour
{
    // 레이스가 스타트가 되면 true로 전환
    private bool startRacing = false;

    // 말의 수. 씬 스크립트에서 수 결정, default = 4
    public int horseNum = 4;

    public float horse_Z = 0f;

    public string horseName;

    // 말이 달리고 있는지의 여부
    public bool inRace = false;

    public bool inRank = false;

    // 말의 속도
    private int speed = 10;

    // 경과된 시간 측정용
    private int time = 0;

    private Animator animator;

    private int rotateFlag = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        animator = GetComponent<Animator>();
        horse_Z = transform.position.z;
        inRace = true;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (startRacing)
        {
            time++;
            HorseRun();
            if (time == 100)
            {
                time = 0;
                SetRandomSpeed();
                SetRandomRotate();
            }
            if (horse_Z >= 127.7f)
            {
                inRace = false;
            }
        }
    }

    // 말의 이동 함수
    private void HorseRun()
    {
        transform.Translate(Vector3.forward/100*speed);
        horse_Z = transform.position.z;
        if (rotateFlag < 5 && inRace)
        {
            speed = 0;
            transform.Rotate(0f, 18f, 0f);
        }
    }

    // random하게 speed를 변화
    private void SetRandomSpeed()
    {
        speed = Random.Range(9, 13);
    }

    private void SetRandomRotate()
    {
        rotateFlag = Random.Range(1, 100);
    }

    public bool GetStartRacing() {  return startRacing; }
    public void SetStartRacing(bool a) {  startRacing = a; }

    public void SetAnimationTrigger()
    {
        animator.SetTrigger("RaceStart");
    }
}
