﻿using BugStore.Application.Services.Customers.Dto.Request;
using BugStore.Domain.Models;
using System.Xml.Linq;

namespace BugStore.Application.Utils;
public class CustomerMethods
{
    public static Customer CreateCustomer(CustomerDtoRequest customerDtoRequest)
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            Name = customerDtoRequest.Name,
            Email = customerDtoRequest.Email,
            Phone = customerDtoRequest.Phone,
            BirthDate = customerDtoRequest.BirthDate
        };
    }
}
