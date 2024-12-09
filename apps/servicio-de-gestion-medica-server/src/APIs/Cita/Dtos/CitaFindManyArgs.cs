using Microsoft.AspNetCore.Mvc;
using ServicioDeGestiNMDica.APIs.Common;
using ServicioDeGestiNMDica.Infrastructure.Models;

namespace ServicioDeGestiNMDica.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CitaFindManyArgs : FindManyInput<Cita, CitaWhereInput> { }
