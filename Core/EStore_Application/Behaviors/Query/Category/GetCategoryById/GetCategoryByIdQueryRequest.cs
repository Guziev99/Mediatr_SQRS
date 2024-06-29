﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore_Application.Behaviors.Query.Category.GetCategoryById
{
    public  class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponce>
    {
        public int Id { get; set; }
    }
}