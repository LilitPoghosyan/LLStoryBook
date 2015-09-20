using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Group
    {
        public Group()
        {
            Stories = new HashSet<Story>();
        }

        [Key]
        public int GroupID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [DisplayName("Number of Members")]
        [NotMapped]
        public int MemberCount
        {
            get
            {
                return Stories.Select(s => s.User).Distinct().Count();
            }
        }

        [DisplayName("Number of Stories")]
        [NotMapped]
        public int StoriesCount
        {
            get
            {
                return Stories.Count();
            }
        }
        public virtual ICollection<Story> Stories { get; set; }

        public override bool Equals(object obj)
        {
            Group gr = obj as Group;
            if (gr == null)
                return false;

            return gr.Name.Equals(this.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
