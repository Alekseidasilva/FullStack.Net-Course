﻿using Dima.Api.Data;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Request.Transations;
using Dima.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class TransationHandler(AppDbContext context) : ITransationHandler
{
    public async Task<Response<Transation?>> CreateAsync(CreateTransationRequest request)
    {
        try
        {
            var transation = new Transation
            {
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.Now,
                Amount = request.Amount,
                PaidOrReceivedAt = request.PaidOrReceivedAt,
                Title = request.Title,
                Type = request.Type
            };
            await context.Transations.AddAsync(transation);
            await context.SaveChangesAsync();
            return new Response<Transation?>(transation, 201, "Transacao criada com Sucesso!");
        }
        catch
        {
            return new Response<Transation?>(null, 500, "Nao foi possivel criar a Transacao");
        }
    }

    public async Task<Response<Transation?>> UpdateAsync(UpdateTransationRequest request)
    {
        try
        {
            var transation = await context.Transations.FirstOrDefaultAsync(trans => trans.Id == request.Id && trans.UserId == request.UserId);
            if (transation == null)
                return new Response<Transation?>(null, 404, "Transacao nao encontrada!");
            transation.Title = request.Title;
            transation.Amount = request.Amount;
            transation.CategoryId = request.CategoryId;
            transation.Type = request.Type;
            transation.PaidOrReceivedAt = request.PaidOrReceivedAt;
            context.Transations.Update(transation);
            await context.SaveChangesAsync();
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return new Response<Transation?>(transation, message: "Transacao atualizada com Sucesso!");

        }
        catch
        {
            return new Response<Transation?>(null, 500, "Nao foi possivel actualizar a Transacao");
        }
    }

    public async Task<Response<Transation?>> DeleteAsync(DeleteTransationRequest request)
    {

        try
        {
            var transation =
                await context.Transations.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            if (transation == null)
                return new Response<Transation?>(null, 404, "Transacao nao encontrada!");
            context.Transations.Remove(transation);
            await context.SaveChangesAsync();
            return new Response<Transation?>(transation, message: "Transacao atualizada com Sucesso!");
        }
        catch
        {
            return new Response<Transation?>(null, 500, "Nao foi possivel excluir a Transacao");
        }
    }

    public async Task<Response<Transation?>> GetByIdAsync(GetTransationByIdRequest request)
    {
        try
        {
            var transation =
                await context.Transations.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            return transation is null ?
                  new Response<Transation?>(null, 404, "Transacao nao encontrada!")
                  : new Response<Transation?>(transation, message: "Transacao atualizada com Sucesso!");
        }
        catch
        {
            return new Response<Transation?>(null, 500, $"Nao foi possivel Obter a Transacao com o Id : {request.Id}");
        }
    }

    public async Task<PagedResponse<List<Transation>>> GetByPeriodAsync(GetTransationByPeriodRequest request)
    {
        var transations = await context.Transations
             .Where(x => x.UserId == request.UserId && x.PaidOrReceivedAt >= request.StartDate && x.PaidOrReceivedAt <= request.EndDate)
             .OrderByDescending(x => x.PaidOrReceivedAt)
             .Skip((request.Page - 1) * request.PageSize)
             .Take(request.PageSize)
             .ToListAsync();
        var total = await context.Transations
            .Where(x => x.UserId == request.UserId && x.PaidOrReceivedAt >= request.StartDate && x.PaidOrReceivedAt <= request.EndDate)
            .CountAsync();
        return new PagedResponse<List<Transation>>()
    }
}