﻿using ProfileMicroService.API.Entities;
using ProfileMicroService.API.Settings.PaginationSettings;

namespace ProfileMicroService.API.Interfaces.Repositories;

public interface IProfileRepository
{
    Task<bool> AddAsync(Profile profile);
    Task<PageList<Profile>> GetAllPaginatedAsync(PageParameters pageParameters);
    Task<bool> ExistsAsync(int id);
}
