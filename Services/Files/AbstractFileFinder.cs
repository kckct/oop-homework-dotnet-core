using System.Collections;

namespace Services.Files
{
    public abstract class AbstractFileFinder : FileFinder
    {
        protected Config config;
        protected string[] files;
        protected int index = -1;

        protected AbstractFileFinder()
        {
        }

        protected AbstractFileFinder(Config config)
        {
            if (config != null)
                this.config = config;
        }


        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current => files[index];

        public bool MoveNext()
        {
            index++;
            return (index < files.Length);
        }

        public void Reset()
        {
            index = -1;
        }

        protected abstract Candidate CreateCandidate(string fileName);
    }
}
