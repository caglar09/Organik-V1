using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using OrganikV1.Core;

namespace OrganikV1.Entities
{
    public class Comments : IEntity
    {
        [Key] public int commentId { get; set; }
        [Required] public int productId { get; set; }
        [Required] public string name { get; set; }
        [Required] public string lastname { get; set; }
        [Required, DataType(DataType.EmailAddress)] public string email { get; set; }
        [Required, DataType(DataType.MultilineText)] public string commentContent { get; set; }
        [Required, DataType(DataType.DateTime)] public DateTime? commentDate { get; set; }
        [Required] public string userId { get; set; }
        [Required] public Boolean activeted { get; set; }
        [Required] public Boolean isDeleted { get; set; }
    }
}
