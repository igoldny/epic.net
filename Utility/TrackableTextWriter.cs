using System.IO;
using System.Text;

namespace Epic.Utility
{
    public class TrackableTextWriter : TextWriter
    {
        private readonly TextWriter _writer;
        private StringBuilder _mem;

        public TrackableTextWriter(TextWriter writer)
        {
            _writer = writer;
            _mem = new StringBuilder();
        }

        public override Encoding Encoding
        {
            get { return _writer.Encoding; }
        }

        public override void Write(string value)
        {
            _writer.Write(value);
            _mem.Append(value);
        }

        public string GetWrittenString()
        {
            return _mem.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                _writer.Dispose();
                _mem = null;
            }
            base.Dispose(disposing);
        }
    }
}