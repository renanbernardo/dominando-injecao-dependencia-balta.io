﻿using DependencyStore.Models;

namespace DependencyStore.Repositories.Contracts;

public interface IPromoCodeRepository
{
    Task<PromoCode?> GetByIdAsync(string promoCode);
}
