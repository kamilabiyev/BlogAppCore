﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlogAppCore.Data.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime RegisteredAt { get; set; }

        [NotMapped]
        public IFormFile ProfilePicture { get; set; }


        // Foreign keys
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }


    }
}