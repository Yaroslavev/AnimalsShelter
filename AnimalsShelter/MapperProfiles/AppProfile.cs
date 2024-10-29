using Data.Enteties;
using AnimalsShelter.Models;
using AutoMapper;

namespace AnimalsShelter.MapperProfiles
{
	public class AppProfile : Profile
	{
		public AppProfile() {
			CreateMap<AddAnimalModel, Animal>();
			CreateMap<Animal, AnimalModel>();
			CreateMap<Animal, EditAnimalModel>();
			CreateMap<EditAnimalModel, Animal>();
		}
	}
}
