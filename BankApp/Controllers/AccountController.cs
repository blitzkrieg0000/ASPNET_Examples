using System.Collections.Generic;
using System.Linq;
using BankApp.Data.Entities;
using BankApp.Data.Interfaces;
using BankApp.Data.UnitOfWork;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.Controllers {
    public class AccountController : Controller {
        //! Constructor 1
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

        //! Constructor 2
        // private readonly IRepository<Account> _accountRepository;
        // private readonly IRepository<ApplicationUser> _userRepository;
        // public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> userRepository) {
        //     _accountRepository = accountRepository;
        //     _userRepository = userRepository;
        // }

        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create(int id) {
            //var userInfo = _userMapper.MapToUserList(_applicationUserRepository.GetUserById(id));
            var userInfo = _unitOfWork.GetRepository<ApplicationUser>().GetById(id);
            return View(new UserListModel {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model) {
            //_accountRepository.Create(_accountMapper.Map(model));
            _unitOfWork.GetRepository<Account>().Create(new Account {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            });
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userId) {
            var query = _unitOfWork.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.ApplicationUserId == userId).ToList();

            var user = _unitOfWork.GetRepository<ApplicationUser>().GetById(userId);
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

            var query = _unitOfWork.GetRepository<Account>().GetQueryable();
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

            return View(new SelectList(list, "Id", "AccountNumber"));
        }


        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model) {

            //var senderAccount = _accountRepository.GetById(model.SenderId);
            var senderAccount = _unitOfWork.GetRepository<Account>().GetById(model.SenderId);

            senderAccount.Balance -= model.Amount;
            _unitOfWork.GetRepository<Account>().Update(senderAccount);

            var account = _unitOfWork.GetRepository<Account>().GetById(model.AccountId);
            account.Balance += model.Amount;
            _unitOfWork.GetRepository<Account>().Update(account);

            _unitOfWork.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}