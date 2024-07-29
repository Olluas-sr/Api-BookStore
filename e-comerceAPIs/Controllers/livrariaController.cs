using e_comerceAPIs.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace livraria.Controllers
{
    [EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class livrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public livrariaController(ToDoContext context)
        {
            _context = context;

            foreach (Produto x in _context.todoProducts)
             _context.todoProducts.Remove(x);
            _context.SaveChanges();

            _context.todoProducts.Add(new Produto { Id = "1", Name = "Coletania Alan Poe", Price = 24.0, Stock = 13, Category = "Terror", Img = "https://i.pinimg.com/236x/3b/ba/0d/3bba0d6b65a12a178cdf2959d1a657a4.jpg" });
            _context.todoProducts.Add(new Produto { Id = "2", Name = "Dracula", Price = 28.0, Stock = 122, Category = "Terror", Img = "https://darkside.vtexassets.com/arquivos/ids/171649/197-2-dracula-de-bram-stoker-dark-edition--2-.jpg?v=637327496337100000" });
            _context.todoProducts.Add(new Produto { Id = "3", Name = "One Piece", Price = 85.0, Stock = 19, Category = "Ação", Img = "https://i.pinimg.com/236x/89/12/0e/89120e7751ab997b40f4729ef7b837ab.jpg" });
            _context.todoProducts.Add(new Produto { Id = "4", Name = "Bleach", Price = 35.0, Stock = 14, Category = "Ação", Img = "https://www.sekinamayu.com/wp-content/uploads/2021/09/Bleach-Manga-Cover-683x1024.jpg" });
            _context.todoProducts.Add(new Produto { Id = "5", Name = "King of Thorns", Price = 100.0, Stock = 13, Category = "Dark Fantasy", Img = "https://m.media-amazon.com/images/I/51FZN+6rntL.jpg" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.todoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> AddProduto(Produto produto)
        {
            _context.todoProducts.Add(produto);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetProdutos), new { id= produto.Id, }, produto);
        }
    }
}
