using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Videogame
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] 
    public string Name { get; set; }
    [Required] 
    public int Pegi { get; set; }
    [Required] 
    public string Description { get; set; }
    [Required] 
    public int Stock { get; set; }
    [Required] 
    public decimal Price { get; set; }
    [Required] 
    public int Discount { get; set; }
    [Required] 
    public DateTime ReleaseDate { get; set; }
    [Required] 
    public string Developer { get; set; }
    [Required] 
    public string Distributor { get; set; }
    [Required] 
    public string PrincipalImageURL { get; set; }

    public string? Requisitos1 { get; set; }
    public string? Requisitos2 { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public Product Product { get; set; }

    public ICollection<VideogameGender> VideogameGenders { get; set; }


    public Videogame() { }

    public Videogame(
        string name,
        int pegi,
        string description,
        int stock,
        decimal price,
        int discount,
        DateTime releaseDate,
        string developer,
        string distributor,
        string principalImageURL,
        int productId,
        string? requisitos1 = null,
        string? requisitos2 = null
    )
    {
        Name = name;
        Pegi = pegi;
        Description = description;
        Stock = stock;
        Price = price;
        Discount = discount;
        ReleaseDate = releaseDate;
        Developer = developer;
        Distributor = distributor;
        PrincipalImageURL = principalImageURL;
        ProductId = productId;
        Requisitos1 = requisitos1;
        Requisitos2 = requisitos2;
    }

    public Videogame mapFromCreateDto(VideogameCreateDTO dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Videogame(
            dto.Name,
            dto.Pegi,
            dto.Description,
            dto.Stock,
            dto.Price,
            dto.Discount,
            dto.ReleaseDate,
            dto.Developer,
            dto.Distributor,
            dto.PrincipalImageURL,
            dto.ProductId,
            dto.Requisitos1,
            dto.Requisitos2
        );
    }

    public VideogameDTO mapToReadDto()
    {
        return new VideogameDTO
        {
            Id = this.Id,
            ProductId = this.ProductId,
            Name = this.Name,
            Pegi = this.Pegi,
            Description = this.Description,
            Requisitos1 = this.Requisitos1,
            Requisitos2 = this.Requisitos2,
            Stock = this.Stock,
            Discount = this.Discount,
            Price = this.Price,
            PrincipalImageURL = this.PrincipalImageURL,
            ReleaseDate = this.ReleaseDate,
            Distributor = this.Distributor,
            Developer = this.Developer,
            Sales = this.Product?.Sales ?? 0 // Ejemplo si quieres incluir datos del Product
        };
    }
}