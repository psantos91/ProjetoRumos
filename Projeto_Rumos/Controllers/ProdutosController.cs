using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using WebApplication2.Data;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Projeto_Rumos.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Projeto_Rumos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _WebHost;

        public ProdutosController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _WebHost = webHost;
        }

        // GET: Produtos
        
        [HttpPost]
        public async Task<IActionResult> SalvarImg(IFormFile ifile)
        {
            try
            {
                string imgext = Path.GetExtension(ifile.FileName);
                if (imgext == ".jpg" || imgext == ".gif" || imgext == ".png" || imgext == ".jpeg")
                {
                    var saveimg = Path.Combine(_WebHost.WebRootPath, "img/images_produtos", ifile.FileName);
                    var stream = new FileStream(saveimg, FileMode.Create);
                    await ifile.CopyToAsync(stream);
                    string nomeProduto = ifile.FileName;
                    ViewBag.Message = nomeProduto;
                    ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Nome", "Nome");
                    return View("CreateProduto");
                }
                else
                {
                    ViewBag.Message = "Erro!! Carregue uma imagem válida";
                    ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Nome", "Nome");
                    return View("CreateProduto");
                }
            }
            catch (Exception msg)
            {

                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }

        // GET: Produtos/Details/5
        

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                Produto produto = new Produto();
                if (id == null)
                {
                    return NotFound();
                }

                produto = await _context.Produtos
                    .FirstOrDefaultAsync(m => m.ProdutoId == id);

                return View(produto);
            }
            catch (Exception msg)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }

        // GET: Produtos/Create
        public IActionResult CreateProduto()
        {
            try
            {
                ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Nome", "Nome");
                return View();
            }
            catch (Exception msg)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string nome, string preco, string descricao, string photoFileName, int stock, Categoria categoria)
        {
            try
            {
                var Preco = float.Parse(preco, CultureInfo.InvariantCulture.NumberFormat);
                var produto = new Produto { Nome = nome, Preco = Preco, Descricao = descricao, PhotoFileName = photoFileName, ImageMimeType = "image/jpeg", Stock = stock, Categoria = categoria };

                if (ModelState.IsValid)
                {
                    _context.Add(produto);
                    await _context.SaveChangesAsync();

                    ViewBag.Message2 = "Produto adicionado com sucesso";
                    return View("CreateProduto");
                }

                
                return View();
            }
            catch (Exception msg)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null)
                {
                    return NotFound();
                }
                return View(produto);
            }
            catch (Exception msg)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Preco, [Bind("ProdutoId,Nome,Descricao,PhotoFileName,ImageMimeType,Stock")] Produto produto)
        {
            try
            {
                var preco = float.Parse(Preco, CultureInfo.InvariantCulture.NumberFormat);
                produto.Preco = preco;

                if (id != produto.ProdutoId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(produto);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProdutoExists(produto.ProdutoId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(ListaProdutosGestao));
                }
                return View(produto);
            }
            catch (Exception msg)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var produto = await _context.Produtos
                    .FirstOrDefaultAsync(m => m.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound();
                }

                return View(produto);
            }
            catch (Exception msg)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(id);
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListaProdutosGestao));
            }
            catch (Exception msg)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel();
                errorViewModel.RequestId = msg.Message;

                return View("_Error", errorViewModel);
            }
        }
        public async Task<IActionResult> ListaProdutosGestao()
        {
            return View(await _context.Produtos.ToListAsync());
        }
        
        public IActionResult MenuGestaoProduto()
        {
            return View();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
