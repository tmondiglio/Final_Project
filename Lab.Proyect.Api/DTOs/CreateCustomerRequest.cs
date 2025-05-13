﻿namespace Lab.Project.Api.DTOs
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegistrarionDate { get; set; }

    }
}
