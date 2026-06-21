using UnityEngine;

public class MoveToNewPositionAndMoveAgain : MonoBehaviour
{
    public Vector2 _previousPosition;
    public Vector2 _newPosition;
    public SpriteRenderer _blackBackgroundHide;
    private Color _color;
    public Transform _playerTransform;
    public float _timeToFade = 2.0f;
    public float _currentTime = 0f;
    private bool _hasMoved = false;
    void Start()
    {
        _color = _blackBackgroundHide.color;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNewPosition();
    }
    public void MoveToNewPosition()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _hasMoved = true;
                      
        }
        if(_hasMoved)
        {
            _currentTime += Time.fixedDeltaTime;
            if (_currentTime < _timeToFade)
            {
                var a = _currentTime / _timeToFade;
                _blackBackgroundHide.color = new Color(_color.r, _color.g, _color.b, a);
            }
            else if (_currentTime < _timeToFade + 1.0f)
            {
                _playerTransform.position = _newPosition;              
            }
            else if (_currentTime < _timeToFade + 2.5f)
            {
                var a =  (_timeToFade + 2.5f - _currentTime) / _timeToFade;
                _blackBackgroundHide.color = new Color(_color.r, _color.g, _color.b, a);          
                _previousPosition = _playerTransform.position;
                _newPosition = Vector2.zero;
            }
            else if(_currentTime < _timeToFade + 3.0f)
            {
                _currentTime = 0;
                _hasMoved = false;
            }

        }
       
    }
}
