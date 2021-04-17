using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class ModifiedCompare : IComparer<Note>
    {
        public int Compare(Note note1, Note note2)
        {
            if (note1.Modified > note2.Modified)
            {
                return - 1;
            }
            if (note1.Modified < note2.Modified)
            {
                return 1;
            }

            return 0;
        }
    }
}
