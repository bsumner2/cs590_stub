using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BulletinBoard_Api.Models {
    public class Post {
        [Required, Key]
        public Guid PostId { get; set; }

        [Required, ForeignKey("Account")]
        public Guid Author { get; set; }

        [Required, StringLength(128)]
        public string Title { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [StringLength(256)]
        public string? Body { get; set; }
    }


}