﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public RoleDTO()
        {
        }
    }
}
