using System;

namespace CoolCode.Domain
{
    public class CodeComment
    {
        public virtual int CodeCommentId { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual User Author { get; set; }
        public virtual string Body { get; set; }

        public virtual CodePost Post { get; set; }
    }
}