﻿using DomainModels.Models;
using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IORRepository ORRepository { get; set; }

        protected IUserRepository UserRepository { get; set; }

        protected IOperationRepository OperationRepository { get; set; }

        protected ILikeRepository LikeRepository { get; set; }


        public BaseController(IORRepository orrepository,
            IUserRepository UserRepository,
            IOperationRepository OperationRepository,
            ILikeRepository LikeRepository)
        {
            ORRepository = orrepository;
            this.UserRepository = UserRepository;
            this.OperationRepository = OperationRepository;
            this.LikeRepository = LikeRepository;
        }

        protected User GetCurrentUser()
        {
            return UserRepository.GetByName(User.Identity.Name);
        }
    }
}