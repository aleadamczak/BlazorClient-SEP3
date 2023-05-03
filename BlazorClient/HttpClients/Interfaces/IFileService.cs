using Domain.DTOs;
using File = Domain.Models.File;

namespace HttpClients.Interfaces;


public interface IFileService
{

    Task<File> CreateAsync(File file);

}