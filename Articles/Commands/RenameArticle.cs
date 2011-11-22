using System;
using Infrastructure;

namespace Articles.Commands
{
    public class RenameArticle : Command
    {
        public readonly Guid Id;
        public readonly string Name;
        public readonly int OriginalVersion;

        public RenameArticle(Guid id, string name, int originalVersion)
        {
            Id = id;
            Name = name;
            OriginalVersion = originalVersion;
        }
    }
}