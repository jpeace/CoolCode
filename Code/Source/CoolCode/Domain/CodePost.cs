using System;
using System.Collections.Generic;

namespace CoolCode.Domain
{
    public class CodePost
    {
        private readonly IList<CodeCategory> _categories;
        private readonly IList<CodeComment> _comments;

        public virtual int CodePostId { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual User Author { get; set; }
        public virtual CodeLanguage Language { get; set; }
        public virtual IEnumerable<CodeCategory> Categories {get { return _categories; }}
        public virtual string Code { get; set; }
        public virtual string Title { get; set; }
        public virtual IEnumerable<CodeComment> Comments { get { return _comments; } }

        public CodePost()
        {
            _categories = new List<CodeCategory>();
            _comments = new List<CodeComment>();
        }
    }
}