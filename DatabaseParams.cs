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
    }
}