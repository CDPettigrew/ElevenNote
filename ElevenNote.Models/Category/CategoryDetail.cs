using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevenNote.Data;

namespace ElevenNote.Models.Category
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
