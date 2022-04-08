using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
   public interface IRobot
    {
        string Model { get; }

        string Id { get; }
    }
}
