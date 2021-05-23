using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Diamss_shooter
{
    public interface iActor
    {
        bool isHover {get; set;}
        bool isPressed {get; set;}
        Rectangle BoundingBox { get; set; }
        bool toRemove { get; set; }
        bool bisDraw { get; set; }
        bool bisUpdate { get; set; }

        bool CollideWith(iActor actor);
        void Initialize();
        void Update();
        void Draw(SpriteBatch pSpriteBatch);
    }
}