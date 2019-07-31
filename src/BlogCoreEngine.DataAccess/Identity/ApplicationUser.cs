﻿using BlogCoreEngine.Core.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogCoreEngine.DataAccess.Data
{
    public class ApplicationUser : IdentityUser
    {
        private Author _author;

        public ApplicationUser() { }

        public ILazyLoader LazyLoader { get; set; }

        public ApplicationUser(ILazyLoader lazyLoader)
        {
            this.LazyLoader = lazyLoader;
        }

        public Guid? AuthorId { get; set; }
        public Author Author
        {
            get => this.LazyLoader.Load(this, ref _author);
            set => _author = value;
        }
    }
}
