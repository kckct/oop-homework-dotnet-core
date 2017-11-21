using Candidates;
using System.Collections;

namespace Services.Files
{
    /// <summary>
    /// AbstractFileFinder 抽象類別
    /// </summary>
    public abstract class AbstractFileFinder : FileFinder
    {
        /// <summary>
        /// Config 設定檔物件
        /// </summary>
        protected Config config;

        /// <summary>
        /// 檔名陣列
        /// </summary>
        protected string[] files;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Config 設定檔物件</param>
        protected AbstractFileFinder(Config config)
        {
            if (config != null)
                this.config = config;
        }

        /// <summary>
        /// 實作 IEnumerable
        /// </summary>
        /// <returns>AbstractFileFinderEnumerator</returns>
        public IEnumerator GetEnumerator()
        {
            return new AbstractFileFinderEnumerator(this);
        }

        /// <summary>
        /// 當實作 IEnumerable 時，必須也要實作 IEnumerator
        /// </summary>
        private class AbstractFileFinderEnumerator : IEnumerator
        {
            /// <summary>
            /// 索引
            /// </summary>
            private int index = -1;

            /// <summary>
            /// Instance
            /// </summary>
            private AbstractFileFinder abstractFileFinder;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="abstractFileFinder">Instance</param>
            public AbstractFileFinderEnumerator(AbstractFileFinder abstractFileFinder)
            {
                this.abstractFileFinder = abstractFileFinder;
            }

            /// <summary>
            /// 實作 IEnumerator
            /// </summary>
            public object Current => abstractFileFinder.CreateCandidate(abstractFileFinder.files[index]);

            /// <summary>
            /// 實作 IEnumerator
            /// </summary>
            public bool MoveNext()
            {
                index++;
                return (index < abstractFileFinder.files.Length);
            }

            /// <summary>
            /// 實作 IEnumerator
            /// </summary>
            public void Reset()
            {
                index = -1;
            }
        }

        /// <summary>
        /// 產生 Candidate object
        /// </summary>
        /// <param name="fileName">檔名</param>
        /// <returns>Candidate object</returns>
        protected abstract Candidate CreateCandidate(string fileName);
    }
}
