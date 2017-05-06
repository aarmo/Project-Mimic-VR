using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObject : MonoBehaviour {

    public string collideTag = "GameController";

    public MiButton button;

    Renderer _rend;
    Text _buttonText;

    private void Start()
    {
        SetupButtonObject();
    }
    
    public void SetupFromTemplate(Transform parent, MiButton template)
    {
        transform.parent = parent;
        transform.position = template.position;

        var m = button;
        m.hover = template.hover;
        m.material = template.material;
        m.buttonName = template.buttonName;

        SetupButtonObject();
    }

    public void SetupButtonObject()
    {
        if (_rend == null) _rend = GetComponent<Renderer>();
        if (_buttonText == null) _buttonText = GetComponentInChildren<Text>();

        _rend.material = button.material;
        _buttonText.text = button.buttonName;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == collideTag)
        {
            var ctl = collision.gameObject.GetComponent<ButtonController>();
            if (ctl == null) return;

            _rend.material = button.hover;
            ctl.activeButton = this;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == collideTag)
        {
            var ctl = collision.gameObject.GetComponent<ButtonController>();
            if (ctl == null) return;

            _rend.material = button.material;
            ctl.activeButton = null;
        }
    }
}
