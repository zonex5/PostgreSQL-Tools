using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTools
{
    public class DatabaseParams
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public char Format { get; set; }
        public string Path { get; set; }

        /// <summary>Unique sufix for dump file name</summary>
        public string NameSufix { get; set; }

        public bool ValidBaseParams
        {
            get
            {
                return !string.IsNullOrEmpty(Host) && !string.IsNullOrEmpty(Port) && !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Password);
            }
        }

        public bool ValidParams
        {
            get
            {
                return ValidBaseParams
                        && !string.IsNullOrEmpty(Database)
                        && !string.IsNullOrEmpty(Path)
                        && char.IsLetter(Format);
            }
        }

        /// <summary>Calculate key '--jobs' from provided dump format</summary>
        public string Jobs
        {
            get
            {
                switch (Format)
                {
                    case 'd': return "--jobs=10";
                    default: return "";
                }
            }
        }

        /// <summary>Calculate key '--compress' from provided dump format</summary>
        public string Compressoin
        {
            get
            {
                switch (Format)
                {
                    case 'c':
                    case 'd': return "--compress=9";
                    default: return "";
                }
            }
        }

        /// <summary>Calculate dump file extension from provided dump format</summary>
        private string Extension
        {
            get
            {
                switch (Format)
                {
                    case 'c': return ".dump";
                    case 'p': return ".sql";
                    case 't': return ".tar";
                    default: return "";
                }
            }
        }

        /// <summary>Calculate dump file name from provided data</summary>
        public string DumpFileName
        {
            get
            {
                return $"{Database}-{NameSufix}{Extension}";
            }
        }

        public DatabaseParams()
        {
            NameSufix = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }
    }
}