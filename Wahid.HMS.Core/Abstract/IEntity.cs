using System;

namespace Wahid.HMS.Core.Abstract
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
