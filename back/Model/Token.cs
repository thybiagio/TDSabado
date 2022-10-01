using System;
using System.Collections.Generic;

namespace Back.Model
{
    public partial class Token
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Value { get; set; } = null!;

        public virtual Usuario? User { get; set; }
    }
}
