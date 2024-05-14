using Core.Bases;

namespace Core.Entities
{
    public class NationalCode : ValueObject
    {
        public required string Code { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}