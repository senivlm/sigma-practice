using System;
using System.Collections.Generic;
using System.Text;

namespace sigma_t5
{
    class PathSplitter
    {
        private string _path;
        public PathSplitter() : this("") { }
        public PathSplitter(String path) 
        { 
            this._path = path.Trim(); 
        }

        public string GetFileName(bool ext = false)
        {
            int from = Math.Max(_path.LastIndexOf('\\'), _path.LastIndexOf('/')) + 1;
            int to = ext ? _path.Length : _path.LastIndexOf('.');
            if (to < from) throw new FormatException();
            return _path.Substring(from, to - from);
        }

        public string GetRootDir()
        {
            int to = Math.Max(_path.LastIndexOf('\\'), _path.LastIndexOf('/'));
            return _path.Substring(0, to);
        }

        public override string ToString()
        {
            return this._path;
        }
    }
}
