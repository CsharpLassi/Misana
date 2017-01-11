﻿using Misana.Core.Components;
using Misana.Core.Ecs;

namespace Misana.Core.Systems
{
    public class NonCollidingMoverSystem : BaseSystemR2N1<MotionComponent, PositionComponent, BlockCollisionComponent>
    {
        protected override void Update(Entity e, MotionComponent r1, PositionComponent r2)
        {
            r2.Position += r1.Move;
        }
    }
}