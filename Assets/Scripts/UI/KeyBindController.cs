using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyBindController : MonoBehaviour
{
    // 1. 변경할 키 버튼을 누름
    // 2. 키입력 대기
    // 3. KeyCode.None이 아니라면, 할당 불가 키에 해당하는지 확인. => 할당 불가 키 리스트 작성 필요
    // 4. 해당 키코드가 이미 사용중인지 확인, 만약 사용중이라면 교체

    [SerializeField]
    private Dictionary<ControlKey, Transform> keyDisplays;

    private void SetKeyDisplay(ControlKey targetKey, KeyCode value)
    {
        // 함수 완성 필요
        if(keyDisplays.ContainsKey(targetKey))
        {
            switch(value)
            {
                case KeyCode.Mouse0:
                    break;
                case KeyCode.Mouse1:
                    break;
                case KeyCode.Mouse2:
                    break;
                default:
                    {
                        string targetString = value.ToString();
                        targetString = targetString.Replace("KeyCode.", "");
                        
                    }
                    break;
            }
        }
    }

    public void ChangeKey(ControlKey targetKey, KeyCode value)
    {
        // 현재 할당하고자 하는 키가 valid한 키가 아니라면, 함수를 종료
        if (!InputManager.Instance.IsValidKey(value))
            return;

        // 현재 value 값을 사용하는 ControlKey가 있는지 확인
        ControlKey key = InputManager.Instance.GetKey(value);
        KeyCode tempValue = KeyCode.None;

        // value 값을 사용하는 ControlKey가 있는 경우, 해당 값을 임시 변수에 저장
        if (key != ControlKey.None)
            tempValue = InputManager.Instance.GetValue(targetKey);

        // targetKey에 value 할당
        InputManager.Instance.SetKey(targetKey, value);
        SetKeyDisplay(targetKey, value);

        // tempValue 값을 가진 ControlKey가 있는 경우, 해당 값을 변경
        if (tempValue != KeyCode.None)
        {
            InputManager.Instance.SetKey(key, tempValue);
            SetKeyDisplay(key, tempValue);
        }
    }

    public KeyCode GetCurrentKeyDown()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                return keyCode;
            }
        }
        return KeyCode.None;
    }

}
