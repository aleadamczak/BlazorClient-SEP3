using Domain.DTOs;
using File = Domain.Models.File;

namespace HttpClients.Interfaces;


public interface IFileService
{

    Task<File> CreateAsync(FileCreationDto file);

    Task<File> GetAsync(int id);

}