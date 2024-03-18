using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<Step> Steps { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
    }
}
