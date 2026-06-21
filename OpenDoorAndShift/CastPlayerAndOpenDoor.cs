using UnityEngine;

public class CastPlayerAndOpenDoor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private BoxCollider2D _collider2D;
    public ContactFilter2D contactFilter;
    public RaycastHit2D[] _nearHits = new RaycastHit2D[10];
    [SerializeField]
    private bool _isNear = false;
    public bool IsNear
    {
        get { return _isNear; }
        set { _isNear = value; }
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IsNear = Physics2D.BoxCast(_collider2D.bounds.center, _collider2D.bounds.size, 0f, Vector2.zero, contactFilter, _nearHits) > 0;
        if(IsNear ==  true)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            spriteRenderer.sprite = null;
        }
    }

}
