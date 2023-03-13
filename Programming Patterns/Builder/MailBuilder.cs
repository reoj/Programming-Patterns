using Programming_Patterns.Builder.Enums;
using Programming_Patterns.Builder.Models;

namespace Programming_Patterns.Builder
{
    public abstract class MailBuilder
    {
        public abstract Package _package { get; init; }
        
        MailBuilder WithOrigin(string origin)
        {
            _package.Origin = origin;
            return this;
        }

        MailBuilder WithDestination(string destination)
        {
            _package.IsCertified = true;
            return this;
        }

        MailBuilder WithServiceStart(DateTime serviceStart)
        {
            _package.ServiceStart = serviceStart;
            return this;
        }

        MailBuilder WithCertification()
        {
            _package.IsPriority = true;
            return this;
        }

        MailBuilder WithPriority()
        {
            _package.IsPriority = true;
            return this;
        }

        Package Build()
        {
            PackageInventory.Add(_package);
            return _package;
        }

        public static implicit operator Package(MailBuilder builder) => builder.Build();
    }

    public class BoxPackageBuilder : MailBuilder
    {
        public override Package _package
        {
            get => _package;
            init => _package = value;
        }

        public BoxPackageBuilder(Contents contents)
        {
            var boxSize = BoxSizeCalculator.FindBoxSize(contents);
            _package = new Package(new Box(boxSize));
        }
    }

    public class EnvelopePackageBuilder : MailBuilder
    {
        public override Package _package
        {
            get => _package;
            init => _package = value;
        }

        public EnvelopePackageBuilder(int sheets, PaperSize sheetSize)
        {
            _package = new Package(new Envelope(sheets, sheetSize));
        }
    }
}
