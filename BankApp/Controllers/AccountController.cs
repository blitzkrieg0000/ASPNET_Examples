using BankApp.Data.Contexts;
using BankApp.Data.Entities;
using BankApp.Data.Interfaces;
using BankApp.Mappings;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers {
    public class AccountController : Controller {

        private readonly BankContext _context;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;
        public AccountController(BankContext context, IApplicationUserRepository applicationUserRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper) {
            _context = context;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }

        public IActionResult Create(int id) {
            var userInfo = _userMapper.MapToUserList(_applicationUserRepository.GetUserById(id));
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model) {
            _accountRepository.Create(_accountMapper.Map(model));
            return RedirectToAction("Index", "Home");
        }

    }
}