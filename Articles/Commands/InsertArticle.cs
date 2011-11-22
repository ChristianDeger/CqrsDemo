using System;
using Infrastructure;

namespace Articles.Commands
{
    public class InsertArticle : Command
    {
        public readonly Guid Id;
        public readonly string Name;

        public InsertArticle(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}