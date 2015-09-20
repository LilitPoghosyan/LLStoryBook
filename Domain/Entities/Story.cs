using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Story
    {
        public Story()
        {
            Groups = new HashSet<Group>();
        }
        [Key]
        public int StoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        [Required]
        public string Content { get; set; }

        [DisplayName("Posted On")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostedOn { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        [ForeignKey("User")]
        [Browsable(false)]
        [MaxLength(100)]
        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        [NotMapped]
        public Dictionary<string, bool> AllGroups { get; set; }
    }
}
