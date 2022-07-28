using System.Collections.Generic;
using System.Linq;
using BankApp.Data.Entities;
using BankApp.Data.Interfaces;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers {
    public class AccountController : Controller {
        // private readonly IApplicationUserRepository _applicationUserRepository;
        // private readonly IUserMapper _userMapper;
        // private readonly IAccountRepository _accountRepository;
        // private readonly IAccountMapper _accountMapper;
        // public AccountController(IApplicationUserRepository applicationUserRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper) {
        //     _applicationUserRepository = applicationUserRepository;
        //     _userMapper = userMapper;
        //     _accountRepository = accountRepository;
        //     _accountMapper = accountMapper;
        // }

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ApplicationUser> _userRepository;
        public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> userRepository) {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public IActionResult Create(int id) {
            //var userInfo = _userMapper.MapToUserList(_applicationUserRepository.GetUserById(id));
            var userInfo = _userRepository.GetById(id);
            return View(new UserListModel {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model) {
            //_accountRepository.Create(_accountMapper.Map(model));
            _accountRepository.Create(new Account {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userId) {
            var query = _accountRepository.GetQueryable();
            var accounts = query.Where(x => x.ApplicationUserId == userId).ToList();

            var user = _userRepository.GetById(userId);
            ViewBag.FullName = user.Name + " " + user.Surname;
            var list = new List<AccountListModel>();

            foreach (var account in accounts) {
                list.Add(new() {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult SendMoney(int accountId) {

            var query = _accountRepository.GetQueryable();
            var accounts = query.Where(x => x.Id != accountId).ToList();

            var list = new List<AccountListModel>();

            ViewBag.SenderId = accountId;

            foreach (var account in accounts) {
                list.Add(new() {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }

            return View();
        }
    }
}