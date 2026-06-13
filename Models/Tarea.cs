
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoEF.Models
{
	public class Tarea
	{
		public Guid TareaId { get; set; }

		public Guid CategoriaId { get; set; }
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public PrioridadTarea PrioridadTarea { get; set; }
		public DateTime FechaCreacion { get; set; }
		public int Puntos { get; set; }

		public virtual Categoria Categoria { get; set; }

		public string Resumen {get; set;}
	}

	public enum PrioridadTarea
	{
		Baja,
		Media,
		Alta
	}
}
