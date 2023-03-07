using Programming_Patterns.Builder.Contracts;
using Programming_Patterns.Builder.Models;

namespace Programming_Patterns.Builder
{
    internal class MailBuilder
    {
        private readonly Package _package;
        public MailBuilder WithPriority()
        {
            _package.IsPriority = true;
            return this;
        }

        public MailBuilder WithCertification()
        {
            _package.IsCertified = true;
            return this;
        }

        public MailBuilder WithServiceStart(DateTime serviceStart)
        {
            _package.ServiceStart = serviceStart;
            return this;
        }

        public MailBuilder WithOrigin(string origin)
        {
            _package.Origin = origin;
            return this;
        }

        public MailBuilder WithDestination(string destination)
        {
            _package.Destination = destination;
            return this;
        }

        public Package Build()
        {
            PackageInventory.Add(_package);
            return _package;
        }
    }
}
