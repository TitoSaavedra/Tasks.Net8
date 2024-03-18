using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model.Entities
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }

        [Unicode]
        public string Path { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
