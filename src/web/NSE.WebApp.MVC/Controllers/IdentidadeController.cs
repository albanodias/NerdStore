﻿using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);

            //var resposta = await _autenticacaoService.Registro(usuarioRegistro);

            //if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioRegistro);

            if (false) return View(usuarioRegistro);

            //await RealizarLogin(resposta);

            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            if (false) return View(usuarioLogin);

            return RedirectToAction("Index", controllerName: "Home");

            //ViewData["ReturnUrl"] = returnUrl;
            //if (!ModelState.IsValid) return View(usuarioLogin);

            //var resposta = await _autenticacaoService.Login(usuarioLogin);

            //if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioLogin);

            //await RealizarLogin(resposta);

            //if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            //return LocalRedirect(returnUrl);
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}