using System;

namespace Dapper.Build.Models.Base {
    public abstract class Entity {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; } // TODO handler dapper context
        public bool IsDeleted { get; set; }

        protected Entity () {
            Id = Guid.NewGuid ().ToString ().ToUpper ().Replace ("-", "");
            CreatedAt = DateTimeOffset.Now;
        }
    }
}