using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Lib
{
    public enum MenuStates:byte
    {
        BooksAll=1,
        BookById,
        BookAdd,
        BookEdit,
        BookRemove,

        AuthorAll,
        AuthorById,
        AuthorAdd,
        AuthorEdit,
        AuthorRemove,
        Save,
        Exit
    }
}
